using InspectorAddons;
using Interaction;
using UnityEngine;
using Weapon;

namespace Economics
{
    public class TowerShopItem : MonoBehaviour, ITowerShopItem
    {
        [SerializeField] private string _name;
        [SerializeField] private string _description;
        [SerializeField] private float _price;    
        [SerializeField] Sprite _sprite;    
        [SerializeField] private InterfaceComponent<ITower> _towerPrefab;

        private ITower _weaponInfo;

        public float Price => _price;
        public string Name => _name;
        public string Description => _description;
        public ITower Tower => _weaponInfo;
        public Sprite Sprite => _sprite;

        protected void Awake()
        {
            _weaponInfo = _towerPrefab.Interface;
        }  
    }
}