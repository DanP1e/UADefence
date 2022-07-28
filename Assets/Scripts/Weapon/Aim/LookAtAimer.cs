using Effects;
using InspectorAddons;
using System;
using UnityEngine;
using Zenject;

namespace Weapon.Aim
{
    public class LookAtAimer : MonoBehaviour, IAimer
    {
        [Tooltip("Determines what angle of deviation " +
            "from the target is considered the norm")]
        [SerializeField] private float _deviationAngle;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private bool _lockXAxis;
        [SerializeField] private Transform _rotatingObject;

        private IAreaPresenter _areaPresenter;
        private Transform _target;

        public float AimRange 
        { 
            get => _areaPresenter.AreaScale; 
            set => _areaPresenter.AreaScale = value; 
        }

        [Inject]
        public void Construct(IAreaPresenter areaPresenter)
        {
            _areaPresenter = areaPresenter;
        }

        public void StopAim()
        {
            _target = null;
            enabled = false;
        }

        public void StartAiming(Transform target)
        {
            _target = target;           
            enabled = true;
        }

        public bool IsAimed()
        {
            if (_target == null)
                return false;

            Vector3 translatedTarget = _target.position - _rotatingObject.position;
            bool aimed = Vector3.Angle(_rotatingObject.forward, translatedTarget) <= _deviationAngle;
            return aimed == true && _areaPresenter.IsInArea(_target.position);
        }

        private void Update()
        {
            if (_target == null)
                return;

            Vector3 translatedTarget = _target.position - _rotatingObject.position;
            if (_lockXAxis)
                translatedTarget.y = 0;

            var newRotation = Quaternion.LookRotation(translatedTarget);
            _rotatingObject.rotation = Quaternion.Slerp(
                _rotatingObject.rotation,
                newRotation,
                Time.deltaTime * _rotationSpeed);
        }
    }
}
