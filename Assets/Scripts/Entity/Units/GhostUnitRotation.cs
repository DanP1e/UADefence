using System;
using UnityEngine;

namespace Entity.Units
{
    public sealed class GhostUnitRotation : MonoBehaviour, IUnitRotator
    {
        [SerializeField] private float _rotationFactor = 5f;
        [SerializeField] private bool _isMovementFactorAffectRotation = false;

        private Transform _ghost;

        private void Awake()
        {
            _ghost = new GameObject("UnitRotator ghost").transform;
            _ghost.SetParent(transform);
        }

        public void RotateBodyTo(Vector3 target, float movementFactor, IUnit sender)
        {
            _ghost.position = sender.GetUnitPivotPosition();
            _ghost.LookAt(target);

            float factor = _isMovementFactorAffectRotation ? movementFactor : 1;            
            float multiplier = (movementFactor * factor) * _rotationFactor * Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, _ghost.rotation, multiplier);
        }
    }
}
