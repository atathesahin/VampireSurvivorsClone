using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Player Stats")]
    [SerializeField] PlayerStats playerStats;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Slider expSlider;
    [SerializeField] private Slider staminaSlider;
    [SerializeField] private TextMeshProUGUI levelText;

    

    void OnEnable()
    {
        
        playerStats.OnExperienceChanged += ExperienceBar;
        playerStats.OnHealthChanged += UpdateHealthBar;
        playerStats.OnStaminaChanged += UpdateStaminaBar;
        
    }

    private void UpdateHealthBar(float _currentHealth, float _maxHealth)
    {
        healthSlider.value = _currentHealth;
        healthSlider.maxValue = _maxHealth;
    }

    private void ExperienceBar(int _experience, int _maxExperience, int level)
    {
        expSlider.value = _experience;
        expSlider.maxValue = _maxExperience;
        levelText.text = level.ToString();
    }

    private void UpdateStaminaBar(float _currentStamina, float _maxStamina)
    {
        staminaSlider.value = _currentStamina;
        staminaSlider.maxValue = _maxStamina;
    }
    

    public void BackToMainMenu()
    {
        GameManager.Instance.ReturnToMainMenu();
    }

    private void OnDisable()
    {
        playerStats.OnHealthChanged -= UpdateHealthBar;
        playerStats.OnExperienceChanged -= ExperienceBar;
        playerStats.OnStaminaChanged -= UpdateStaminaBar;

    }
}
