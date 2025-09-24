using System;
using System.Collections;
using TMPro;
using UnityEngine;


    public class TimerUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timerText;
        
        private void OnEnable()
        {
            if (GameManager.Instance == null) return;
            GameManager.Instance.OnTimeUpdate += UpdateTimeUI;
            
        }

        private void UpdateTimeUI(float time)
        {
  
            TimeSpan timeSpan = TimeSpan.FromSeconds(time);
            timerText.text = $"{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}";
        }

        private void OnDisable()
        {
            if (GameManager.Instance == null) return;
            GameManager.Instance.OnTimeUpdate -= UpdateTimeUI;
        }
        
    }       