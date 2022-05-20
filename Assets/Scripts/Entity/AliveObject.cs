using System;
using UnityEngine;
using UnityEngine.Events;

namespace Entity
{
    public class AliveObject : MonoBehaviour, IAlive
    {
        [SerializeField] private float _health = 100;
        [SerializeField] private float _maxHealth = 100;

        private bool _aliveFlag = true;

        public UnityEvent Dead;
        public UnityEvent Damaged;

        public float Health => _health;
        public float MaxHealth 
        { 
            get => _maxHealth; 
            protected set => _maxHealth = value; 
        }

        public event Action<float> HealthChanged;

        public bool IsAlive() => _aliveFlag;
        public void MakeDamage(float damage)
        {
            if (damage < 0)
                throw new ArgumentException(
                    $"The {nameof(damage)} value should be great or equal to 0! " +
                    $"If you want to heal use {nameof(Heal)} function!"
                    , nameof(damage));

            float startHealth = _health;
            _health -= damage;
            if (_health <= 0)
            {
                _health = 0;
                if (_aliveFlag == true)
                {
                    _aliveFlag = false;
                    Dead?.Invoke();                   
                }
            }

            HealthChanged?.Invoke(_health - startHealth);
            Damaged?.Invoke();
        }
        public void Heal(float health)
        {
            if (health < 0)
                throw new ArgumentException(
                    $"The {nameof(health)} value should be great or equal to 0! " +
                    $"If you want to make damage use {nameof(MakeDamage)} function!"
                    , nameof(health));

            float startHealth = _health;

            _health += health;

            if (_health > _maxHealth)
                _health = _maxHealth;

            if(_health > 0)
                _aliveFlag = true;

            HealthChanged?.Invoke(_health - startHealth);
            Damaged?.Invoke();
        }
        public void Kill()
            => MakeDamage(Health);
    }
}
