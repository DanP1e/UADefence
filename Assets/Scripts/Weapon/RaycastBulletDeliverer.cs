using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Weapon
{
    public class RaycastBulletDeliverer : MonoBehaviour, IBulletDeliverer
    {
        public float Speed = 40;
        public UnityEvent HitEvent;
        private BulletHit[] Hits;

        private bool TryHitObstacle(Vector3 pos, Vector3 rayDirection, float rayLength) 
        {
            RaycastHit[] raycastHits = Physics.RaycastAll(pos, rayDirection, rayLength);
            Array.Sort(raycastHits, (x, y) => (int)(x.distance - y.distance));

            Hits = new BulletHit[raycastHits.Length];

            if (raycastHits.Length > 0)
            {
                for (int i = 0; i < raycastHits.Length; i++)            
                {
                    //if (IgnorColliders.Contains(raycastHits[i].collider))
                    //    continue;

                    Hits[i] = new BulletHit()
                    {
                        Point = raycastHits[i].point,
                        Normal = raycastHits[i].normal,
                        GameObject = raycastHits[i].transform.gameObject
                    };
                    transform.position = raycastHits[i].point;

                    HitEvent?.Invoke();
                    //Hits = null;
                    return true;
                }                              
            }
            return false;
        }
        private IEnumerator Flight()
        {
            while (true)
            {
                Vector3 rayDirection = transform.forward * Speed * Time.fixedDeltaTime;
                float rayLength = rayDirection.magnitude;
                yield return new WaitForFixedUpdate();         
                if (TryHitObstacle(transform.position, rayDirection, rayLength))
                {
                    yield return new WaitForFixedUpdate();
                }                      
                transform.position += rayDirection;                          
            }
        }

        public void Throw(Vector3 direction)
        {
            StartCoroutine(Flight());
        }

        public BulletHit[] GetCurrentHits() => Hits;
    }
}
