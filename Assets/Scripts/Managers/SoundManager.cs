using System;
using UnityEngine;

    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance;

        #region Singleton

        private void Awake()
        {
            if (Instance != null)
                Instance = this;
            else 
                Destroy(this);
        }
        
        #endregion

        private void Update()
        {
            
        }

       
    }
