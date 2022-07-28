using InspectorAddons;
using UnityEngine;
using ViewControllers;

namespace ZenjectInstallers
{
    public class IconFactoryInstaller : InterfaceInstaller<IIconFactory>
    {
        [SerializeField] private InterfaceComponent<IIconFactory> _iconFactoryComponent;

        protected override IIconFactory Interface => _iconFactoryComponent.Interface;
    }
}
