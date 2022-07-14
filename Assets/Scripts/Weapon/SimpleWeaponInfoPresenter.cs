using Effects;
using InspectorAddons;
using System;
using UnityEngine;

namespace Weapon
{
    public class SimpleWeaponInfoPresenter : MonoBehaviour, IWeaponInfoPresenter
    {
        [SerializeField] private InterfaceComponent<ITimer> _fireTimerComponent;
        [SerializeField] private InterfaceComponent<ITimer> _reloadTimerComponent;
        [SerializeField] private InterfaceComponent<IMonoBulletMagazine> _magazineComponent;

        private float _fireRate;
        private float _reloadSpeed;
        private int _magazineMaxCapacity;
        private string _damagePerShotInfoText;

        public float FireRate => _fireRate;
        public float ReloadSpeed => _reloadSpeed;
        public string DamagePerShot => _damagePerShotInfoText;
        public int MagazineMaxCapacity => _magazineMaxCapacity;

        private void Awake()
        {
            var damageMaker = (IDamageMaker)_magazineComponent.Interface.GetBullet()
                .Object.GetComponent(typeof(IDamageMaker));
            if (damageMaker == null)
                throw new NullReferenceException("The bullet object does not have " +
                    "a component that implements interface IDamageMaker!");

            _damagePerShotInfoText = $"{damageMaker.MinDamage} - {damageMaker.MaxDamage}";
            _magazineMaxCapacity = _magazineComponent.Interface.MaxCapacity;
            _fireRate = _fireTimerComponent.Interface.Interval;
            _reloadSpeed = _reloadTimerComponent.Interface.Interval;
        }
    }
}
