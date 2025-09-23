using System;
using UnityEngine;


public class PlayerStats : StatManager
{
    [Header("Experience Stats")]
    private int Level = 1;
    
    private int maxExperince = 100;
    [Space]
    [Header("Basic Stats")] 
    [SerializeField] private float maxStamina = 10;
    [SerializeField] private float staminaRegen;
    public float currentStamina = 10;
        
    
    #region Events
    
    public event Action<float,float> OnHealthChanged;
    public event Action<int,int,int> OnExperienceChanged;
    public event Action<float,float> OnStaminaChanged;
    
    #endregion
    
    void Update()
    {
        GainStamina();
        GainExperience();

    }
    protected override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        OnHealthChanged?.Invoke(currentHealth,maxHealth);
    }
    private void GainExperience()
    {
        
        OnExperienceChanged?.Invoke(currentExperience,maxExperince,Level);
        
        if (currentExperience >= maxExperince)
        {
            currentExperience = 0;
            LevelUp();
        }
    }

    private void GainStamina()
    {
      
        if (currentStamina < maxStamina)
        {
            currentStamina += staminaRegen * Time.deltaTime;
        }
        else if(currentStamina >= maxStamina)
            currentStamina = maxStamina;
        
        OnStaminaChanged?.Invoke(currentStamina,maxStamina);
    }

    private void LevelUp()
    {
        Level++;
        maxExperince += 100;
        OnExperienceChanged?.Invoke(currentExperience,maxExperince,Level);
    }

    protected override void Die()
    {
        base.Die();                                                                                                                                                     
    
    }
    

   
    
    

   
    
}
