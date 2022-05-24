using Effects;
using System;
using UnityEngine;

namespace Weapon
{
    public class SphericalAreaPresenter : MonoBehaviour, IAreaPresenter
    {
        [SerializeField] private float _range = 12f;

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _range);
        }       

        public bool IsInArea(Vector3 targetPosition)
        {
            return Vector3.Distance(transform.position, targetPosition) <= _range;
        }
    }
}
