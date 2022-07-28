using Interaction;
using UnityEngine;
using UnityEngine.Events;

namespace Economics
{
    public interface IShopItem
    {
        float Price { get; }
        string Name { get; }
        Sprite Sprite { get; }
    }
}