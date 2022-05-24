using System;
using UnityEngine;
using UnityEngine.Events;

namespace Entity
{
    public class AliveObject : MonoBehaviour, IAlive
    {
        [SerializeField] private float _health = 100;
        [SerializeField] private float _maxHealth = 100;
        [SerializeField] private UnityEvent<IAlive> _died;
        [SerializeField] private UnityEvent<IAlive, float> _damaged;
        [SerializeField] private UnityEvent<IAlive, float> _healed;

        private bool _aliveFlag = true;        

        public float Health => _health;
        public float MaxHealth 
        { 
            get => _maxHealth; 
            protected set => _maxHealth = value; 
        }
        public UnityEvent<IAlive> Died { get => _died; }
        public UnityEvent<IAlive, float> Damaged { get => _damaged; }
        public UnityEvent<IAlive, float> Healed { get => _healed; }

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
                    Died?.Invoke(this);                  
                }
            }

            Damaged?.Invoke(this, _health - startHealth);
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

            Healed?.Invoke(this, _health - startHealth);
        }
        public void Kill()
            => MakeDamage(Health);
    }
}
