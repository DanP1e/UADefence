using Entity;
using InspectorAddons;
using System;
using UnityEngine;

namespace Weapon
{
    public class ExplosionSimulator : MonoBehaviour
    {
        [SerializeField] private float _explosionForce = 500;
        [SerializeField] private float _explosionRadius = 3;

        public void Explode(InterfaceComponent<IAlive> aliveTargets) 
        {
            Rigidbody rb = aliveTargets.Object.GetComponent<Rigidbody>();
            if (rb != null)
                rb.AddExplosionForce(_explosionForce, transform.position, _explosionRadius); 
        }
    }
}
