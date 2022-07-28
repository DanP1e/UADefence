using UnityEngine;

namespace Weapon
{
    public interface IBulletThrower
    {
        void Throw(IBulletRepresentative bulletPrefab, Vector2 damage);
    }
}