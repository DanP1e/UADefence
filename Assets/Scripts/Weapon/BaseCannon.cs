using Effects;
using Entity;
using InspectorAddons;
using UnityEngine;
using Weapon.Aim;
using Zenject;

namespace Weapon
{
    public class BaseCannon : MonoBehaviour, ICannon
    {
        [Min(0, order = 0)]
        [SerializeField] private Vector2 _damage = new Vector2(5, 7);

        private Component _target;
        private bool _isSkeeped = false;
        private ITimer _fireTimer;
        private ITimer _reloadTimer;
        private IBulletThrower _bulletThrower;
        private IAimer _aimer;
        private IMagazine _magazine;
        private ITargetPresenter<InterfaceComponent<IAlive>> _targetPresenter;

        public Vector2 Damage { get => _damage; set => _damage = value; }

        #region Injection

        [Inject]
        public void Construct(
            IBulletThrower bulletThrower,
            IAimer aimer,
            IMagazine magazine,
            ITargetPresenter<InterfaceComponent<IAlive>> targetPresenter,
            [Inject(Id = "fire")] ITimer fire,
            [Inject(Id = "reload")] ITimer reload)
        {
            _bulletThrower = bulletThrower;
            _aimer = aimer;
            _magazine = magazine;
            _targetPresenter = targetPresenter;
            _fireTimer = fire;
            _reloadTimer = reload;

            _fireTimer.TimeoutEvent.AddListener(Fire);
            _reloadTimer.TimeoutEvent.AddListener(OnReloadTimeout);
            _reloadTimer.IsCyclical = false;
        }
        #endregion

        private void UpdateTarget()
        {
            InterfaceComponent<IAlive> component;
            if (!_targetPresenter.TryGetTargetComponent(transform.position, out component))
                return;

            _target = component.Object.transform;
            _aimer.StartAiming(_target.transform);
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

            IBulletRepresentative bullet;
            if (!_magazine.TryGetNextBullet(out bullet))
            {
                _fireTimer.StopTimer();
                _reloadTimer.StartTimer();
                _magazine.TryReload();
                _isSkeeped = false;
                return;
            }
            else
            {
                _bulletThrower.Throw(bullet, _damage);
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
    }
}
