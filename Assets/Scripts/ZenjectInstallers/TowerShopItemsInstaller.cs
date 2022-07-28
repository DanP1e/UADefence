using Economics;
using InspectorAddons;
using System.Collections.Generic;
using UnityEngine;

namespace ZenjectInstallers
{
    [RequireComponent(typeof(ITowerShopItem))]
    public class TowerShopItemsInstaller : InterfaceInstaller<List<ITowerShopItem>>
    {
        protected override List<ITowerShopItem> Interface => GetItems();

        private List<ITowerShopItem> GetItems()
        {
            Component[] components = GetComponents(typeof(ITowerShopItem));

            List<ITowerShopItem> result = new List<ITowerShopItem>();

            foreach (var component in components)
            {
                ITowerShopItem shopItem = component as ITowerShopItem;
                if(shopItem != null)
                    result.Add(shopItem);
            }

            return result;
        }
    }
}
