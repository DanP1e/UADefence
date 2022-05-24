using Effects;
using Entity;
using InspectorAddons;
using System;
using UnityEngine;
using Weapon.Aim;

namespace Weapon
{
    public sealed class BaseCannon : MonoBehaviour
    {
        [SerializeField] private InterfaceComponent<IBulletThrower> _bulletThrowerComponent;
        [SerializeField]
        InterfaceComponent<ITargetPresenter<InterfaceComponent<IAlive>>> _targetPresenterComponent;
        [SerializeField] private InterfaceComponent<IAimer> _aimerComponent;
        [SerializeField] private InterfaceComponent<ITimer> _fireTimerComponent;
        [SerializeField] private InterfaceComponent<ITimer> _reloadTimerComponent;
        [Min(1)]
        [SerializeField] private int _clipLength = 15;

        private IBulletThrower _bulletThrower;
        private ITargetPresenter<InterfaceComponent<IAlive>> _targetPresenter;
        private IAimer _aimer;
        private ITimer _fireTimer;
        private ITimer _reloadTimer;
        private int _bulletCounter;
        private Component _target;

        private void Awake()
        {
            _bulletThrower = _bulletThrowerComponent.Interface;
            _targetPresenter = _targetPresenterComponent.Interface;
            _fireTimer = _fireTimerComponent.Interface;
            _reloadTimer = _reloadTimerComponent.Interface;
            _aimer = _aimerComponent.Interface;

            _fireTimer.TimeoutEvent.AddListener(Fire);
            _reloadTimer.TimeoutEvent.AddListener(OnReloadTimeout);
            _reloadTimer.IsCyclical = false;
        }
        private void OnEnable()
        {
            _fireTimer.StartTimer();
            _bulletCounter = _clipLength;
        }
        private void OnDisable()
        {
            _fireTimer.StopTimer();
        }
        private void Fire()
        {
            if (!_aimer.IsAimed())
            {
                UpdateTarget();
                return;
            }

            _bulletThrower.Throw();
            _bulletCounter--;            

            if (_bulletCounter <= 0)
            {
                _fireTimer.StopTimer();
                _reloadTimer.StartTimer();
                _bulletCounter = _clipLength;
            }
        }     
        private void OnReloadTimeout()
        {
            _fireTimer.StartTimer();
            _reloadTimer.StopTimer();
        }

        public void UpdateTarget()
        {
            InterfaceComponent<IAlive> component;
            if (!_targetPresenter.TryGetTargetComponent(transform.position, out component))
                return;

            _target = component.Object.transform;
            _aimer.StartAiming(_target.transform);
        }
    }
}
