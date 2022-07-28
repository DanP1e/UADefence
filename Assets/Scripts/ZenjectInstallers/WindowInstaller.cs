using InspectorAddons;
using UnityEngine;
using ViewControllers;

namespace ZenjectInstallers
{
    public class WindowInstaller : InterfaceWithIdInstaller<IWindow>
    {
        [SerializeField] private InterfaceComponent<IWindow> _windowComponent;

        protected override IWindow Interface => _windowComponent.Interface;
    }
}
