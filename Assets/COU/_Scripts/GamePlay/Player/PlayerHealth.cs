using System;
using COU.Interfaces;
using UnityEngine;

namespace COU.Player
{
    public class PlayerHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] private int _maxHealth;
        
        private int _currentHealth;
        
        public int CurrentHealth => _currentHealth;
        public int MaxHealth => _maxHealth;

        public event Action TakeDamageEvent;

        public void Initialize()
        {
            _currentHealth = _maxHealth;
        }
        
        public void TakeDamage(int damage)
        {
            if (damage > 0)
            {
                _currentHealth -= damage;
                TakeDamageEvent?.Invoke();
                if (_currentHealth <= 0)
                    Die();
            }
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}