using InspectorAddons;
using UnityEngine;
using ViewControllers;

namespace ZenjectInstallers
{
    public class WindowsHandlerInstaller : InterfaceInstaller<IWindowsHandler>
    {
        [SerializeField] private InterfaceComponent<IWindowsHandler> _windowsHandlerComponent;

        protected override IWindowsHandler Interface => _windowsHandlerComponent.Interface;
    }
}
