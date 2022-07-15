using InspectorAddons;
using UnityEngine;
using Weapon.Aim;

namespace ZenjectInstallers
{
    public class AreaPresenterInstaller : InterfaceInstaller<IAreaPresenter>
    {
        [SerializeField] private InterfaceComponent<IAreaPresenter> _areaPresenterComponent;

        protected override IAreaPresenter Interface => _areaPresenterComponent.Interface;
    }
}
