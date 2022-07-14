using System;
using UnityEngine;

namespace Entity.Units
{
    public class AroundUnitRotator : MonoBehaviour, IUnitRotator
    {
        [SerializeField] private float _yawFactor = 40f;
        [SerializeField] private float _pitchFactor = 40f;
        [SerializeField] private bool _isMovementFactorAffectRotation = false;

        private Vector2 V3ToV2(Vector3 vector3)
           => new Vector2(vector3.x, vector3.z);

        public virtual void RotateBodyTo(Vector3 target, float movementFactor, IUnit sender)
        {
            float factor = _isMovementFactorAffectRotation ? movementFactor : 1;
            Vector3 pivotPoint = sender.GetUnitPivotPosition();
            Vector3 rotateDirecton = target - sender.GetInteractPoint();

            float dot = Vector2.Dot(V3ToV2(transform.right), V3ToV2(rotateDirecton));
            float horizontalStep = (dot < 0 ? -1 : 1) * Time.deltaTime * _yawFactor * factor;
            transform.RotateAround(pivotPoint, Vector3.up, horizontalStep);

            float verticalStep = rotateDirecton.y * Time.deltaTime * _pitchFactor * factor;
            transform.RotateAround(pivotPoint, -transform.right, verticalStep);
        }
    }
}
