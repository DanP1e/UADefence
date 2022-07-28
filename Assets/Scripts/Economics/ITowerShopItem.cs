using Weapon;

namespace Economics
{
    public interface ITowerShopItem : IShopItem
    {
        string Description { get; }
        ITower Tower { get; }
    }
}