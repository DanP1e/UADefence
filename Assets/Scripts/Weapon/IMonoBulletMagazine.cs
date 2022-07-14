using InspectorAddons;

namespace Weapon
{
    interface IMonoBulletMagazine : IMagazine
    {
        InterfaceComponent<IBulletDeliverer> GetBullet();
    }
}
