using InspectorAddons;
using UnityEngine;
using ViewControllers;
using Zenject;

namespace Economics
{
    public class WalletViewUpdater : MonoBehaviour
    {
        private IWalletViewController _walletViewController;
        private IWallet _wallet;

        [Inject]
        public void Construct(
            IWallet wallet, 
            IWalletViewController walletViewController) 
        {
            _wallet = wallet;
            _walletViewController = walletViewController;
            _walletViewController.ChangeAccountView(_wallet.Credits);
            _wallet.AccountChanged += OnWalletAccountChanged;
        }

        private void OnWalletAccountChanged()
            => _walletViewController.ChangeAccountView(_wallet.Credits);    
    }
}
