using InspectorAddons;
using UnityEngine;
using UnityEngine.Events;

namespace Entity.Units
{
    public class Unit : MonoBehaviour, IUnit
    {
        [SerializeField] private Vector3 _interactPointOffset;
        [SerializeField] private Vector3 _unitPivotPointOffset;
        [SerializeField] private InterfaceComponent<IUnitRotator> _unitRotatorComponent;

        private IUnitRotator _unitRotator;

        private void Awake()
        {
            _unitRotator = _unitRotatorComponent.Interface;
        }
        private void OnDrawGizmos()
        {
            Gizmos.DrawSphere(GetInteractPoint(), 0.5f);
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(GetUnitPivotPosition(), 0.5f);
        }
            
        public Vector3 GetUnitPivotPosition() 
            => transform.position + transform.rotation * _unitPivotPointOffset;   
        public Vector3 GetInteractPoint()
            => transform.position + transform.rotation * _interactPointOffset;
        public virtual void MakeMovementFrame(Vector3 target, float movementFactor)
        {
            _unitRotator.RotateBodyTo(target, movementFactor, this);
            transform.position += transform.forward * Time.deltaTime * movementFactor;
        }
    }
}
