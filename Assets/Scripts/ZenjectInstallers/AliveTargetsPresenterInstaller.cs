using Entity;
using InspectorAddons;
using UnityEngine;
using Weapon;

namespace ZenjectInstallers
{
    public class AliveTargetsPresenterInstaller : InterfaceInstaller<ITargetPresenter<InterfaceComponent<IAlive>>>
    {
        [SerializeField] 
        private InterfaceComponent<ITargetPresenter<InterfaceComponent<IAlive>>> _aliveTargetsPresenter;

        protected override ITargetPresenter<InterfaceComponent<IAlive>> Interface => _aliveTargetsPresenter.Interface;
    }
}
