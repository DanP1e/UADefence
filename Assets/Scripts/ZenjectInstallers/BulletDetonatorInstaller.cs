using InspectorAddons;
using UnityEngine;
using Weapon;

namespace ZenjectInstallers
{
    public class BulletDetonatorInstaller : InterfaceInstaller<IDetonator>
    {
        [SerializeField] private InterfaceComponent<IDetonator> _bulletDetonatorComponent;

        protected override IDetonator Interface => _bulletDetonatorComponent.Interface;
    }
}
