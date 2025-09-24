using System;
using UnityEngine;

    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance;

        #region Singleton

        private void Awake()
        {
            if (Instance = null)
            { 
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else 
                Destroy(this);
        }
        
        #endregion

        private void Update()
        {
            
        }

       
    }
