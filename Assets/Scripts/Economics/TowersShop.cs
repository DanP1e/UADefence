using InspectorAddons;
using Interaction;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;
using ViewControllers;
using System;
using Weapon;

namespace Economics
{
    public sealed class TowersShop : MonoBehaviour
    {
        [SerializeField] private InterfaceComponent<IBuyButton> _buyButtonComponent;
        [SerializeField] private string _nonePriceText = "-";

        private Dictionary<IIcon, ITowerShopItem> _iconItemAssociations
            = new Dictionary<IIcon, ITowerShopItem>();
        private List<ITowerShopItem> _shopItems = new List<ITowerShopItem>();
        private IWallet _playerWallet;
        private ITowerShopItem _selectedShopItem;
        private IBuyButton _buyButton;
        private IIconFactory _iconFactory;
        private IWindow _shopWindow;
        private ITowerPlacer _towerPlacer;
        private IInteractiveObjectsUser _interactiveObjectsUser;

        public event UnityAction<IShopItem> ItemBought;

        #region Injection
        [Inject]
        public void Construct(
            List<ITowerShopItem> shopItems,
            IWallet wallet,
            IIconFactory iconFactory,
            [Inject(Id = "towersShop")]
            IWindow shopWindow,
            ITowerPlacer towerPlacer,
            IInteractiveObjectsUser interactiveObjectsUser)
        {
            _shopItems = shopItems;
            _playerWallet = wallet;
            _buyButton = _buyButtonComponent.Interface;
            _iconFactory = iconFactory;
            _shopWindow = shopWindow;
            _towerPlacer = towerPlacer;
            _interactiveObjectsUser = interactiveObjectsUser;

            CreateNewIcons();

            _playerWallet.AccountChanged += UpdateBuyButton;
            _buyButton.ButtonPressed += OnBuyButtonClicked;
            _buyButton.Interactable = false;
            _buyButton.SetText(_nonePriceText);
        }
        #endregion

        private void OnDisable()
        {
            _selectedShopItem = null;
            _buyButton.SetText(_nonePriceText);
            _buyButton.Interactable = false;
            UnselectAll();
        }

        private void OnBuyButtonClicked()
        {
            if (_selectedShopItem != null
            && _playerWallet.TryGetWithdraw(_selectedShopItem.Price))
                ItemBought?.Invoke(_selectedShopItem);

            UpdateBuyButton();           

            _towerPlacer.PlaceTower(
                _selectedShopItem.Tower, 
                _interactiveObjectsUser.InteractionPoint);

            _shopWindow.Hide();
        }

        private void OnIconSelected(ISelectable selectableIcon)
        {
            IIcon icon = (IIcon)selectableIcon;
            ITowerShopItem item;

            if (!_iconItemAssociations.TryGetValue(icon, out item))
                throw new Exception("This icon has no association with its item!");

            UnselectIconsExept(icon);

            _selectedShopItem = item;
            UpdateBuyButton();
            _buyButton.SetText(_selectedShopItem.Price.ToString());
        }

        private bool IsCanPurchase()
        {
            return _selectedShopItem != null 
                && _playerWallet.Credits >= _selectedShopItem.Price;
        }

        private void CreateNewIcons()
        {
            DestroyIcons();

            foreach (var item in _shopItems)
            {
                IIcon icon = _iconFactory.CreateNewIcon(item.Sprite);
                icon.Selected.AddListener(OnIconSelected);
                _iconItemAssociations.Add(icon, item);
            }
        }

        private void DestroyIcons()
        {
            foreach (var iconItem in _iconItemAssociations)
            {
                iconItem.Key.Selected.RemoveListener(OnIconSelected);
                iconItem.Key.Destroy();
            }

            _iconItemAssociations.Clear();
        }

        private void UpdateBuyButton()
        {
            _buyButton.Interactable = IsCanPurchase();
            _buyButton.SetText(
                _selectedShopItem == null 
                ? _nonePriceText 
                : _selectedShopItem.Price.ToString());
        }

        private void UnselectIconsExept(IIcon icon) 
        {
            foreach (var iconItem in _iconItemAssociations)
                if (iconItem.Key != icon)
                    iconItem.Key.Unselect();
        }

        private void UnselectAll()
        {
            foreach (var iconItem in _iconItemAssociations)
                iconItem.Key.Unselect();
        }
    }
}
