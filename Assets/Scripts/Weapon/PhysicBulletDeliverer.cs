using System;
using UnityEngine;
using UnityEngine.Events;

namespace Weapon
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public class PhysicBulletDeliverer : MonoBehaviour, IBulletDeliverer
    {
        [SerializeField] private float _force = 5;
        private Rigidbody _rigidbody;

        public UnityEvent HitEvent;
        private BulletHit[] Hits;

        protected void Awake() 
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.isKinematic = true;
        }
        protected void OnCollisionEnter(Collision collision)
        {
            Hits = new BulletHit[collision.contactCount];
            for (int i = 0; i < Hits.Length; i++)
            {
                Hits[i].GameObject = collision.contacts[i].otherCollider.gameObject;
                Hits[i].Normal = collision.contacts[i].normal;
                Hits[i].Point = collision.contacts[i].point;
            }
            HitEvent?.Invoke();
            Hits = null;
        }

        public void Throw(Vector3 direction)
        {
            _rigidbody.isKinematic = false;
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.AddForce(direction.normalized * _force);
        }

        public BulletHit[] GetCurrentHits() => Hits;
    }
}
