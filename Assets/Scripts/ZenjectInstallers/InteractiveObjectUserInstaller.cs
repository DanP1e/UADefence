using InspectorAddons;
using Interaction;
using UnityEngine;

namespace ZenjectInstallers
{
    public class InteractiveObjectUserInstaller : InterfaceInstaller<IInteractiveObjectsUser>
    {
        [SerializeField] private InterfaceComponent<IInteractiveObjectsUser> _interactiveObjectsUserComponent;

        protected override IInteractiveObjectsUser Interface => _interactiveObjectsUserComponent.Interface;
    }
}
