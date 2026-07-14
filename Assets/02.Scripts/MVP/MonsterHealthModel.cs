using System;
using UnityEngine;

namespace DesignPatterns.MVP
{
    public class MonsterHealthModel : MonoBehaviour
    {
        public event Action OnHealthChanged; // 체력이 변경되었을때 Presenter 에게 알려주는 이벤트

        [SerializeField] private int maxHealth = 100;
        private int currentHealth;
        public int MaxHealth => maxHealth;
        public int CurrentHealth => currentHealth;
        public bool IsDead => currentHealth <= 0;
        private void Awake()
        {
            currentHealth = maxHealth;
        }
        public void Takedamage(int damage)
        {
            if (IsDead) return;
            currentHealth -= damage;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

            OnHealthChanged?.Invoke();
        }
        public void Heal(int amount)
        {
            if (IsDead) return;
            currentHealth += amount;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            OnHealthChanged?.Invoke();
        }
        public void ResetHealth()
        {
            currentHealth = maxHealth;
            OnHealthChanged?.Invoke();
        }
    }
}
