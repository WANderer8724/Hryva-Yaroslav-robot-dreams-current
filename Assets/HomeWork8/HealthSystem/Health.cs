using System;
using UnityEngine;

namespace Dummies
{
    public class Health : MonoBehaviour
    {
        public event Action<int> OnHealthChanged;
        public event Action<float> OnHealthChanged01;
        public event Action<Health> OnDeath;

        [SerializeField] protected Collider _collider;
        [SerializeField] protected int _maxHealth;

        protected int _health;
        protected bool _isAlive;
        protected float _maxHealthReciprocal;

        public int HealthValue
        {
            get => _health;
            set
            {
                if (_health == value)
                    return;
                _health = value;
                OnHealthChanged?.Invoke(_health);
                OnHealthChanged01?.Invoke(_health * _maxHealthReciprocal);
            }
        }

        public bool IsAlive
        {
            get => _isAlive;
            set
            {
                if (_isAlive == value)
                    return;
                _isAlive = value;
                if (!_isAlive)
                    OnDeath?.Invoke(this);
            }
        }

        public float HealthValue01 => HealthValue * _maxHealthReciprocal;
        public int MaxHealthValue => _maxHealth;
        public Collider Collider => _collider;

        protected virtual void Awake()
        {
            SetHealth(MaxHealthValue);
            _maxHealthReciprocal = 1f / _maxHealth;
        }

        public void TakeDamage(int damage)
        {
            if (!IsAlive)
                return;

            HealthValue = Mathf.Clamp(HealthValue - damage, 0, _maxHealth);
            if (HealthValue <= 0)
                Debug.Log(HealthValue);
                IsAlive = false;
        }

        public void Heal(int heal)
        {
            if (!IsAlive)
                return;

            HealthValue = Mathf.Clamp(HealthValue + heal, 0, _maxHealth);
        }

        public void SetHealth(int health)
        {
            HealthValue = Mathf.Clamp(health, 0, _maxHealth);
            IsAlive = HealthValue > 0;
        }
    }
}