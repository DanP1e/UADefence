using InspectorAddons;
using Interaction;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Economics
{
    public sealed class TowersShop : MonoBehaviour
    {
        [SerializeField] private Button _buyButton;
        [SerializeField] private Button _sellButton;
        [SerializeField] private InterfaceComponent<IWallet> _playerWalletComponent;
        [SerializeField] private List<InterfaceComponent<IShopItem>> _shopItemsComponents;

        private List<IShopItem> _shopItems = new List<IShopItem>();
        private IWallet _playerWallet;
        private IShopItem _selectedShopItem;
        private IShopItem _boughtShopItem;

        private void Awake()
        {
            _playerWallet = _playerWalletComponent.Interface;

            foreach (var item in _shopItemsComponents)
                _shopItems.Add(item.Interface);

            _buyButton.onClick.AddListener(OnBuyButtonClicked);
            _sellButton.onClick.AddListener(OnSellButtonClicked);         

            foreach (var item in _shopItems)
            {
                item.Selected.AddListener(OnItemSelected);
                item.Unselected.AddListener(OnItemUnselected);
            }

            if (_boughtShopItem == null)
            {
                _sellButton.interactable = false;
                _buyButton.interactable = true;
            }
        }

        private void OnSellButtonClicked()
        {
            if (_boughtShopItem == null)
                throw new NothingToSellException();

            if (_boughtShopItem.Sell(_playerWallet))
            {
                _boughtShopItem = null;
                _sellButton.interactable = false;
                _buyButton.interactable = true;
            }
        }

        private void OnBuyButtonClicked()
        {
            if (_boughtShopItem != null)
                throw new DoubleBuyException();

            if(_selectedShopItem.Buy(_playerWallet))
                _boughtShopItem = _selectedShopItem;
        }

        private void OnItemSelected(ISelectable item)
        {
            _selectedShopItem = item as IShopItem;
        }

        private void OnItemUnselected(ISelectable item)
        {
            _selectedShopItem = null;
        }
    }
}
