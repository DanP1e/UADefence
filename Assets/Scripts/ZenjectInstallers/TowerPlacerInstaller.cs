using InspectorAddons;
using UnityEngine;
using Weapon;

namespace ZenjectInstallers
{
    public class TowerPlacerInstaller : InterfaceInstaller<ITowerPlacer>
    {
        [SerializeField] private InterfaceComponent<ITowerPlacer> _towerPlacerComponent;

        protected override ITowerPlacer Interface => _towerPlacerComponent.Interface;
    }
}
