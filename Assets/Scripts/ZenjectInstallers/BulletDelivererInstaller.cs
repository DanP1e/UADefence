using InspectorAddons;
using UnityEngine;
using Weapon;

namespace ZenjectInstallers
{
    public class BulletDelivererInstaller : InterfaceInstaller<IBulletDeliverer>
    {
        [SerializeField] private InterfaceComponent<IBulletDeliverer> _bulletDelivererComponent;

        protected override IBulletDeliverer Interface => _bulletDelivererComponent.Interface;
    }
}
