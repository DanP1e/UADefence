using InspectorAddons;

namespace Weapon
{
    public interface IMagazine
    {
        int MaxCapacity { get; set; }
        int Charges { get; }

        bool TryGetNextBullet(out IBulletRepresentative bulletRepresentative);
        bool TryReload();
    }
}
