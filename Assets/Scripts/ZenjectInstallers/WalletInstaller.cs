using Economics;
using InspectorAddons;
using UnityEngine;

namespace ZenjectInstallers
{
    public class WalletInstaller : InterfaceInstaller<IWallet>
    {
        [SerializeField] private InterfaceComponent<IWallet> _walletComponent;

        protected override IWallet Interface => _walletComponent.Interface;
    }
}
