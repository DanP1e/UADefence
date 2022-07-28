using InspectorAddons;
using UnityEngine;
using Weapon;

namespace ZenjectInstallers
{
    public class DamageMakerInstaller : InterfaceInstaller<IDamageMaker>
    {
        [SerializeField] private InterfaceComponent<IDamageMaker> _damageMakerComponent;

        protected override IDamageMaker Interface => _damageMakerComponent.Interface;
    }
}
