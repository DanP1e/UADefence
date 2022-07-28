using UnityEngine;

namespace Weapon
{
    public interface IBulletRepresentative
    {
        GameObject BulletRootObject { get; }
        IDamageMaker DamageMaker { get; }
        IBulletDeliverer Deliverer { get; }
    }
}
