using InspectorAddons;
using UnityEngine;

namespace Weapon
{
    public class MonoBulletMagazine : MonoBehaviour, IMonoBulletMagazine
    {
        [Min(1)]
        [SerializeField] private int _maxCapacity;
        [Min(0)]
        [SerializeField] private int _charges;
        [SerializeField] private InterfaceComponent<IBulletDeliverer> _bulletDelivererComponent;

        public int MaxCapacity => _maxCapacity;
        public int Charges => _charges;

        public InterfaceComponent<IBulletDeliverer> GetBullet()
            => _bulletDelivererComponent;

        public bool TryGetNextBullet(out InterfaceComponent<IBulletDeliverer> bulletDeliverer)
        {
            _charges--;
            bulletDeliverer = _charges >= 0 ? _bulletDelivererComponent : null;
            return _charges >= 0;
        }

        public bool TryReload()
        {
            _charges = _maxCapacity;
            return true;
        }
    }
}
