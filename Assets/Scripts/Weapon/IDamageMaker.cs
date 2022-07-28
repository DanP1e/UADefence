using UnityEngine;

namespace Weapon
{
    public interface IDamageMaker
    {
        float MaxDamage { get; }
        float MinDamage { get; }

        void SetDamage(Vector2 minMaxDamage);
    }
}