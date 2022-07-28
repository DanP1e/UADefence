using UnityEngine;
using UnityEngine.Events;

namespace Weapon
{
    public interface ITower
    {
        public GameObject TowerGameObject { get; }
        public Vector2 MinMaxDamage { get; }
        public float ReloadSpeed { get; }
        public float FireRate { get; }
        public float ShotRange { get; }
        public int MagazineMaxCapacity { get; }

        public event UnityAction<ITower> Destroyed;
    }
}
