using UnityEngine;
using UnityEngine.Events;

namespace Entity.Units
{
    public class Unit : MonoBehaviour, IUnit
    {
        [SerializeField] private Vector3 _interactPointOffset;
        [SerializeField] private Vector3 _unitPivotPointOffset;
        [SerializeField] private float _rotationFactor = 10f;

        private void OnDrawGizmos()
        {
            Gizmos.DrawSphere(GetInteractPoint(), 0.5f);
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(GetUnitPivotPosition(), 0.5f);
        }
        private Vector2 V3ToHorizontalV2(Vector3 vector3)
            => new Vector2(vector3.x, vector3.z);
        private void RotateBodyTo(Vector3 target, float speed)
        {
            //Vector2 directionToTarget2D = V3ToV2(target - GetUnitPivotPosition()).normalized;
            //Vector2 transformForward2DDirection = V3ToV2(transform.forward);
            //Vector2 transformRight2DDirection = V3ToV2(transform.right);

            //float dot = Vector2.Dot(transformRight2DDirection, directionToTarget2D);
            //float factor = dot < 0 ? -1 : 1;
            //float angle = Vector2.Angle(transformForward2DDirection, directionToTarget2D);
            //float rotateStep = Time.deltaTime * _rotationFactor * speed;
            //rotateStep = Mathf.Min(rotateStep, angle);

            //Vector2 rotateVector = Vector2.Lerp(transformForward2DDirection, directionToTarget2D, rotateStep);

            //rotateStep *= factor;

            Vector3 pivotPoint = GetUnitPivotPosition();
            Vector3 rotateDirecton = target - pivotPoint;

            float rotateStep = Vector2.Angle(V3ToHorizontalV2(rotateDirecton), V3ToHorizontalV2(transform.forward));
            float dot = Vector2.Dot(V3ToHorizontalV2(transform.right), V3ToHorizontalV2(rotateDirecton));
            rotateStep *= (dot < 0 ? -1 : 1) * Time.deltaTime * _rotationFactor;

            transform.RotateAround(
                pivotPoint,
                Vector3.up,
                rotateStep);
        }
       
        protected Vector3 GetUnitPivotPosition() 
            => transform.position + transform.rotation * _unitPivotPointOffset;
     
        public Vector3 GetInteractPoint()
            => transform.position + transform.rotation * _interactPointOffset;
        public virtual void MakeMovementFrame(Vector3 target, float speed)
        {
            RotateBodyTo(target, speed);
            transform.position += transform.forward * Time.deltaTime * speed;
        }
    }
}
