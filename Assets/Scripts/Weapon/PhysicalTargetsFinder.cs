using System.Collections.Generic;
using UnityEngine;

namespace Weapon
{
    public class PhysicalTargetsFinder : MonoBehaviour, IPhysicalTargetsFinder
    {
        [SerializeField] private float _findRadius = 4f;

        public List<Rigidbody> FindRigidbodies()
        {
            List<Rigidbody> rigidbodies = new List<Rigidbody>();

            Collider[] colliders = Physics.OverlapSphere(transform.position, _findRadius);
            foreach (var item in colliders)
            {
                Rigidbody rb = item.transform.GetComponent<Rigidbody>();
                if (rb != null)
                    rigidbodies.Add(rb);
            }

            return rigidbodies;
        }
    }
}
