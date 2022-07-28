using InspectorAddons;
using UnityEngine;
using ViewControllers;

namespace ZenjectInstallers
{
    public class WalletViewControllerInstaller : InterfaceInstaller<IWalletViewController>
    {
        [SerializeField] 
        private InterfaceComponent<IWalletViewController> _walletViewControllerComponent;

        protected override IWalletViewController Interface => _walletViewControllerComponent.Interface;
    }
}
