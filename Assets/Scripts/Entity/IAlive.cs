using System;

namespace Entity
{
    public interface IAlive
    {
        event Action<float> HealthChanged;

        float Health { get; }
        float MaxHealth { get; }

        void MakeDamage(float damage);
        void Heal(float health);
        void Kill();
        bool IsAlive();
    } 
}
