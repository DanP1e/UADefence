using InspectorAddons;
using UnityEngine;
using Weapon;

namespace ZenjectInstallers
{
    public class BulletRepresentativeInstaller : InterfaceInstaller<IBulletRepresentative>
    {
        [SerializeField] 
        private InterfaceComponent<IBulletRepresentative> _bulletRepresentativeComponent;

        protected override IBulletRepresentative Interface => _bulletRepresentativeComponent.Interface;
    }
}
