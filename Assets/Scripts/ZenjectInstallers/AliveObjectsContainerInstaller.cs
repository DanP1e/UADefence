using Entity;
using InspectorAddons;
using UnityEngine;
using Utilities;

namespace ZenjectInstallers
{
    public class AliveObjectsContainerInstaller : InterfaceInstaller<IContainer<InterfaceComponent<IAlive>>>
    {
        [SerializeField] 
        private InterfaceComponent<IContainer<InterfaceComponent<IAlive>>> _aliveObjectsContainer;

        protected override IContainer<InterfaceComponent<IAlive>> Interface => _aliveObjectsContainer.Interface;
    }
}
