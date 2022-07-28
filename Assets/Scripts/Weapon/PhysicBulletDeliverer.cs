using UnityEngine;
using UnityEngine.Events;

namespace Weapon
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public class PhysicBulletDeliverer : MonoBehaviour, IBulletDeliverer
    {
        [SerializeField] private float _force = 5;

        private Rigidbody _rigidbody;
        private BulletHit[] hits;

        public event UnityAction<BulletHit> ObjectHit;

        public void Throw(Vector3 direction)
        {
            _rigidbody.isKinematic = false;
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.AddForce(direction.normalized * _force);
        }

        public BulletHit[] GetCurrentHits() => hits;

        protected void Awake() 
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.isKinematic = true;
        }

        protected void OnCollisionEnter(Collision collision)
        {
            hits = new BulletHit[collision.contactCount];
            for (int i = 0; i < hits.Length; i++)
            {
                hits[i].GameObject = collision.contacts[i].otherCollider.gameObject;
                hits[i].Normal = collision.contacts[i].normal;
                hits[i].Point = collision.contacts[i].point;
                ObjectHit?.Invoke(hits[i]);
            }
            
            hits = null;
        }      
    }
}
