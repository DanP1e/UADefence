using InspectorAddons;
using Interaction;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Weapon;

namespace Economics
{
    public class TowerShopItem : SelectableObject, ITowerShopItem
    {
        [Header("Shop")]
        [SerializeField] private string _name;
        [SerializeField] private string _description;
        [SerializeField] private float _price;
        [SerializeField] private Texture2D _icon;
        [SerializeField] private InterfaceComponent<IWeaponInfoPresenter> _weaponInfoPresenterComponent;
        [Header("Scene")]
        [SerializeField] private InterfaceComponent<ISelectable> _selectableImageComponent;
        [SerializeField] private UnityEvent<IShopItem> _bought;
        [SerializeField] private UnityEvent<IShopItem> _sold;

        private IWeaponInfoPresenter _weaponInfoPresenter;
        private ISelectable _selectableImage;

        public float Price => _price;
        public string Name => _name;
        public Texture2D Icon => _icon;
        public string Description => _description;
        public IWeaponInfoPresenter WeaponInfoPresenter => _weaponInfoPresenter;
        public UnityEvent<IShopItem> Bought => _bought;
        public UnityEvent<IShopItem> Sold => _sold;

        private void Awake()
        {
            _weaponInfoPresenter = _weaponInfoPresenterComponent.Interface;
            _selectableImage = _selectableImageComponent.Interface;
        }

        public bool Buy(IWallet wallet)
        {
            if (wallet.TryGetWithdraw(_price))
            {
                gameObject.SetActive(true);
                _bought?.Invoke(this);
                return true;
            }

            return false;
        }
        public bool Sell(IWallet wallet)
        {
            wallet.Deposit(_price);
            gameObject.SetActive(false);
            _sold?.Invoke(this);

            return true;        
        }

        protected override bool OnSelecting()
        {          
            return _selectableImage.Select();
        }
        protected override bool OnUnselecting()
        {
            return _selectableImage.Unselect();
        }
    }
}