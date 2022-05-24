using Effects;
using InspectorAddons;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace Weapon.Aim
{
    public class LookAtAimer : MonoBehaviour, IAimer
    {
        [Tooltip("Determines what angle of deviation " +
            "from the target is considered the norm")]
        [SerializeField] private float _deviationAngle;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private bool _lockXAxis;
        [SerializeField] private InterfaceComponent<IAreaPresenter> _areaPresenterComponent;

        private IAreaPresenter _areaPresenter;
        private Transform _target;

        private void Awake()
        {
            _areaPresenter = _areaPresenterComponent.Interface;
        }
        private void Update()
        {
            if (_target == null)
                return;

            Vector3 translatedTarget = _target.position - transform.position;
            if(_lockXAxis)
                translatedTarget.y = 0;

            var newRotation = Quaternion.LookRotation(translatedTarget);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                newRotation,
                Time.deltaTime * _rotationSpeed);
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

            Vector3 translatedTarget = _target.position - transform.position;
            bool aimed = Vector3.Angle(transform.forward, translatedTarget) <= _deviationAngle;
            return aimed == true && _areaPresenter.IsInArea(_target.position);
        }
    }
}
