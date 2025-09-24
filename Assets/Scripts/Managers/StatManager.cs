using System;
using UnityEngine;


    public class StatManager : MonoBehaviour
    {
        [Header("Health Stats")]
        [SerializeField] protected float currentHealth;
        [SerializeField] protected float maxHealth;
        [Space]
        [Header("Basic Stats")]
        [SerializeField] protected float moveSpeed;
        [SerializeField] protected float damage;

        protected virtual void TakeDamage(float damage)
        {
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Die();
                
            }
            
        }
        
        protected virtual void Die()
        {
            Destroy(gameObject);
        }
        
        public float CurrentHealth
        {
            get => currentHealth;
            set => currentHealth = (value > maxHealth) ? maxHealth : value;
        }

        public float MoveSpeed
        {
            get => moveSpeed;
            set => moveSpeed = value;
        }
        
        public float Damage
        {
            get => damage;
            set => damage = value;
        }

        
        
        
        
    }
