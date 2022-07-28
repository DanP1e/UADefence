using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Weapon
{
    public class RaycastBulletDeliverer : MonoBehaviour, IBulletDeliverer
    {
        [SerializeField] private float _speed = 800;

        private BulletHit[] _hits;

        public event UnityAction<BulletHit> ObjectHit;

        public void Throw(Vector3 direction)
        {
            StartCoroutine(Flight());
        }

        public BulletHit[] GetCurrentHits() => _hits;

        private bool TryHitObstacle(Vector3 pos, Vector3 rayDirection, float rayLength) 
        {
            RaycastHit[] raycastHits = Physics.RaycastAll(pos, rayDirection, rayLength);
            Array.Sort(raycastHits, (x, y) => (int)(x.distance - y.distance));

            _hits = new BulletHit[raycastHits.Length];

            if (raycastHits.Length > 0)
            {
                for (int i = 0; i < raycastHits.Length; i++)            
                {
                    _hits[i] = new BulletHit()
                    {
                        Point = raycastHits[i].point,
                        Normal = raycastHits[i].normal,
                        GameObject = raycastHits[i].transform.gameObject
                    };
                    transform.position = raycastHits[i].point;

                    ObjectHit?.Invoke(_hits[i]);
                    return true;
                }                              
            }
            return false;
        }

        private IEnumerator Flight()
        {
            while (true)
            {
                Vector3 rayDirection = transform.forward * _speed * Time.fixedDeltaTime;
                float rayLength = rayDirection.magnitude;
                yield return new WaitForFixedUpdate();         
                if (TryHitObstacle(transform.position, rayDirection, rayLength))
                {
                    yield return new WaitForFixedUpdate();
                    break;
                }                      
                transform.position += rayDirection;                          
            }
        }      
    }
}
