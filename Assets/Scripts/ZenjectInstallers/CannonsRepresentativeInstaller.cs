using InspectorAddons;
using UnityEngine;
using Weapon;

namespace ZenjectInstallers
{
    public class CannonsRepresentativeInstaller : InterfaceInstaller<ICannonsRepresentative>
    {
        [SerializeField] private InterfaceComponent<ICannonsRepresentative> _cannonsRepresentativeComponent;

        protected override ICannonsRepresentative Interface => _cannonsRepresentativeComponent.Interface;
    }
}
