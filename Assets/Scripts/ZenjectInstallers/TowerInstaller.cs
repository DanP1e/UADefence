using InspectorAddons;
using UnityEngine;
using Weapon;

namespace ZenjectInstallers
{
    public class TowerInstaller : InterfaceInstaller<ITower>
    {
        [SerializeField] private InterfaceComponent<ITower> _towerComponent;

        protected override ITower Interface => _towerComponent.Interface;
    }
}
