using InspectorAddons;

namespace Weapon
{
    public interface IMagazine
    {
        int MaxCapacity { get; }
        int Charges { get; }

        bool TryGetNextBullet(out InterfaceComponent<IBulletDeliverer> bulletDeliverer);
        bool TryReload();
    }
}
