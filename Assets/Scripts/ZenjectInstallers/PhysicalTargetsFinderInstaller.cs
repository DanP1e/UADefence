using InspectorAddons;
using UnityEngine;
using Weapon;

namespace ZenjectInstallers
{
    public class PhysicalTargetsFinderInstaller : InterfaceInstaller<IPhysicalTargetsFinder>
    {
        [SerializeField] private InterfaceComponent<IPhysicalTargetsFinder> _physicalTargetsFinder;

        protected override IPhysicalTargetsFinder Interface => _physicalTargetsFinder.Interface;
    }
}
