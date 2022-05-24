using System;
using UnityEngine.Events;

namespace Entity
{
    public interface IAlive
    {
        public UnityEvent<IAlive> Died { get; }
        public UnityEvent<IAlive, float> Damaged { get; }
        public UnityEvent<IAlive, float> Healed { get; }

        float Health { get; }
        float MaxHealth { get; }

        void MakeDamage(float damage);
        void Heal(float health);
        void Kill();
        bool IsAlive();
    } 
}
