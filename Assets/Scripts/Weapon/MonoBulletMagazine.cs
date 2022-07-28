using InspectorAddons;
using UnityEngine;

namespace Weapon
{
    public class MonoBulletMagazine : MonoBehaviour, IMagazine
    {
        [Min(1)]
        [SerializeField] private int _maxCapacity;
        [SerializeField] private InterfaceComponent<IBulletRepresentative> _bulletComponent;

        private int _charges = 1;

        protected virtual void Awake() 
        {
            TryReload();
        }

        public int MaxCapacity
        { 
            get => _maxCapacity; 

            set
            { 
                _maxCapacity = value;
                TryReload();
            } 
        }

        public int Charges => _charges;

        public bool TryGetNextBullet(out IBulletRepresentative bullet)
        {
            _charges--;
            bullet = _charges >= 0 ? _bulletComponent.Interface : null;
            return _charges >= 0;
        }

        public bool TryReload()
        {
            _charges = _maxCapacity;
            return true;
        }
    }
}
