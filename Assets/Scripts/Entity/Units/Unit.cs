using UnityEngine;
using UnityEngine.Events;

namespace Entity.Units
{
    public class Unit : MonoBehaviour, IUnit
    {
        [SerializeField] private Vector3 _interactPointOffset;
        [SerializeField] private Vector3 _unitPivotPointOffset;
        [SerializeField] private float _yawFactor = 40f;
        [SerializeField] private float _pitchFactor = 40f;
        [SerializeField] private bool _isMovementFactorAffectRotation = false;

        private void OnDrawGizmos()
        {
            Gizmos.DrawSphere(GetInteractPoint(), 0.5f);
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(GetUnitPivotPosition(), 0.5f);
        }
        private Vector2 V3ToV2(Vector3 vector3)
            => new Vector2(vector3.x, vector3.z);

        private void RotateBodyTo(Vector3 target, float movementFactor)
        {
            float factor = _isMovementFactorAffectRotation ? movementFactor : 1;
            Vector3 pivotPoint = GetUnitPivotPosition();
            Vector3 rotateDirecton = target - GetInteractPoint();

            float dot = Vector2.Dot(V3ToV2(transform.right), V3ToV2(rotateDirecton));
            float horizontalStep = (dot < 0 ? -1 : 1) * Time.deltaTime * _yawFactor * factor;
            transform.RotateAround(pivotPoint, Vector3.up, horizontalStep);

            float verticalStep = rotateDirecton.y * Time.deltaTime * _pitchFactor * factor;
            transform.RotateAround(pivotPoint, -transform.right, verticalStep);
        }
       
        protected Vector3 GetUnitPivotPosition() 
            => transform.position + transform.rotation * _unitPivotPointOffset;
     
        public Vector3 GetInteractPoint()
            => transform.position + transform.rotation * _interactPointOffset;
        public virtual void MakeMovementFrame(Vector3 target, float movementFactor)
        {
            RotateBodyTo(target, movementFactor);
            transform.position += transform.forward * Time.deltaTime * movementFactor;
        }
    }
}
