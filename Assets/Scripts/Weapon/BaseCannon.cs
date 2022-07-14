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
        [SerializeField] private InterfaceComponent<IMagazine> _magazineComponent;

        private IBulletThrower _bulletThrower;
        private ITargetPresenter<InterfaceComponent<IAlive>> _targetPresenter;
        private IAimer _aimer;
        private ITimer _fireTimer;
        private ITimer _reloadTimer;
        private IMagazine _magazine;
        private Component _target;
        private bool _isSkeeped = false;

        private void Awake()
        {
            _bulletThrower = _bulletThrowerComponent.Interface;
            _targetPresenter = _targetPresenterComponent.Interface;
            _fireTimer = _fireTimerComponent.Interface;
            _reloadTimer = _reloadTimerComponent.Interface;
            _aimer = _aimerComponent.Interface;
            _magazine = _magazineComponent.Interface;

            _fireTimer.TimeoutEvent.AddListener(Fire);
            _reloadTimer.TimeoutEvent.AddListener(OnReloadTimeout);
            _reloadTimer.IsCyclical = false;
        }
        private void OnEnable()
        {
            _fireTimer.StartTimer();
        }
        private void OnDisable()
        {
            _fireTimer.StopTimer();
        }
        private void Update()
        {
            if (_isSkeeped)
                Fire();
        }
        private void Fire()
        {
            _isSkeeped = true;
            if (!_aimer.IsAimed())
            {
                _fireTimer.StopTimer();
                UpdateTarget();
                return;
            }
            InterfaceComponent<IBulletDeliverer> bullet;

            if (!_magazine.TryGetNextBullet(out bullet))
            {
                _fireTimer.StopTimer();
                _reloadTimer.StartTimer();
                _magazine.TryReload();
            }
            else
            {
                _bulletThrower.Throw();            
            }

            if (!_fireTimer.IsStarted)
                _fireTimer.StartTimer();

            _isSkeeped = false;
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
