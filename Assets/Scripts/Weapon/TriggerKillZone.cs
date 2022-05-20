using Entity;
using System;
using UnityEngine;

namespace Weapon
{
    [RequireComponent(typeof(Collider))]
    public class TriggerKillZone : MonoBehaviour
    {
        private Collider _collider;
      
        private void OnTriggerEnter(Collider col)
        {
            IAlive unit = (IAlive)col.gameObject.GetComponent(typeof(IAlive));
            if (unit != null)
                unit.Kill();
        }
        private void OnDrawGizmos()
        {
            Collider col = GetCollider();
            Gizmos.color = Color.red;
            Gizmos.DrawCube(col.bounds.center, col.bounds.size);
        }
        private Collider GetCollider()
        {
            if (_collider == null)
                _collider = GetComponent<Collider>();

            return _collider;
        }
    }
}
