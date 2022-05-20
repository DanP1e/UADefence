using InspectorAddons;
using PathSystem;
using System;
using UnityEngine;

namespace Entity.Units
{
    public abstract class UnitDriver : MonoBehaviour, IDriver
    {
        [SerializeField] private InterfaceComponent<IUnit> _unitComponent;      
        [SerializeField] private float _speed = 10f;

        private float _maxSpeed = 10f;

        public float MaxSpeed => _maxSpeed;
        public float Speed
        {
            get => _speed;
            set 
            {
                _speed = Mathf.Clamp(value, 0, _maxSpeed);
                SpeedChanged?.Invoke(_speed);
            }
        }
        public IUnit Unit { get; private set; }

        public event Action<float> SpeedChanged;

        public abstract void MoveTo(Vector3 target);
        public abstract void Stop();

        protected virtual void Awake()
        {
            _maxSpeed = _speed;

            if (_unitComponent != null)
                Unit = _unitComponent.Interface;
        }
    }
}
