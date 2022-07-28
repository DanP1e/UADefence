using Entity;
using InspectorAddons;
using UnityEngine;
using Weapon;

namespace ZenjectInstallers
{
    public class AliveTargetsFinderInstaller 
        : InterfaceInstaller<ITargetsFinder<InterfaceComponent<IAlive>>>
    {
        [SerializeField] 
        private InterfaceComponent<ITargetsFinder<InterfaceComponent<IAlive>>> _aliveTargetsFinder;

        protected override ITargetsFinder<InterfaceComponent<IAlive>> Interface 
            => _aliveTargetsFinder.Interface;
    }
}
