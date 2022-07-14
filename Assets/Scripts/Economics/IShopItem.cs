using Interaction;
using UnityEngine;
using UnityEngine.Events;

namespace Economics
{
    public interface IShopItem : ISelectable
    {
        float Price { get; }
        string Name { get; }
        Texture2D Icon { get; }

        bool Buy(IWallet wallet);
        bool Sell(IWallet wallet);

        UnityEvent<IShopItem> Bought { get; }
        UnityEvent<IShopItem> Sold { get; }
    }
}