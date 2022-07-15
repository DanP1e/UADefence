using InspectorAddons;
using UnityEngine;
using Weapon;

namespace ZenjectInstallers
{
    public class BulletThrowerInstaller : InterfaceInstaller<IBulletThrower>
    {
        [SerializeField] private InterfaceComponent<IBulletThrower> _bulletThrowerComponent;

        protected override IBulletThrower Interface => _bulletThrowerComponent.Interface;
    } 
}