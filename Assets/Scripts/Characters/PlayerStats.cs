using System;
using UnityEngine;


public class PlayerStats : StatManager
{
    [Header("Experience Stats")]
    private int Level = 1;
    [SerializeField] private int currentExperience;
    [SerializeField] private int maxExperince = 100;
    [Space]
    [Header("Stamina Stats")] 
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

    }
    protected override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        OnHealthChanged?.Invoke(currentHealth,maxHealth);
        
    }
    public void GainExperience(int amount)
    {
        currentExperience += amount;
       
        
        if (currentExperience >= maxExperince)
        {
            currentExperience -= maxExperince;
            LevelUp();
        }
        OnExperienceChanged?.Invoke(currentExperience,maxExperince,Level);
    }
    private void LevelUp()
    {
        Level++;
        maxExperince += 100;
        OnExperienceChanged?.Invoke(currentExperience,maxExperince,Level);
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

    public void ReceivedDamage(float damage)
    {
        TakeDamage(damage);
      
    }
    protected override void Die()
    {
        GameManager.Instance.GameOver();
    
    }
    

   
    
    

   
    
}
