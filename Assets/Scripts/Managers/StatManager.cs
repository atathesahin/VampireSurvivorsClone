using System;
using UnityEngine;


    public class StatManager : MonoBehaviour
    {
        [Header("Health Stats")]
        [SerializeField] protected float currentHealth;

        
        [SerializeField] protected float maxHealth;
        [SerializeField] protected int currentExperience;
        [Space]
        [Header("Basic Stats")]
        [SerializeField] protected float moveSpeed;
        [SerializeField] protected float damage;
     
        [SerializeField] protected float healthRegen;
       
        


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

        public int CurrentExperience
        {
            get => currentExperience;
            set => currentExperience = value;
        }
        public float Damage
        {
            get => damage;
            set => damage = value;
        }

        
        
        
        
    }
