using InspectorAddons;
using UnityEngine;
using Utilities;
using Weapon;

namespace ZenjectInstallers
{
    public class CannonsContainersInstaller : InterfaceInstaller<IContainer<ICannon>>
    {
        [SerializeField] private InterfaceComponent<IContainer<ICannon>> _cannonContainerComponent;

        protected override IContainer<ICannon> Interface => _cannonContainerComponent.Interface;
    }
}
