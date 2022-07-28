using Entity;
using InspectorAddons;
using UnityEngine;
using UnityEngine.Events;

namespace Weapon
{
    public interface IDamageMaker
    {
        float MaxDamage { get; }
        float MinDamage { get; }

        void SetDamage(Vector2 minMaxDamage);
    }
}