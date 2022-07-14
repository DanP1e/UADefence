using Weapon;

namespace Economics
{
    public interface ITowerShopItem : IShopItem
    {
        string Description { get; }
        IWeaponInfoPresenter WeaponInfoPresenter { get; }
    }
}