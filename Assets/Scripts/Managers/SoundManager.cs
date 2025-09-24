using System;
using UnityEngine;

    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance;
        
        [SerializeField] private AudioSource musicSource;
        [Header("Audio Clips")]
        [SerializeField] private AudioClip mainMenuMusic;
        [SerializeField] private AudioClip gamePlayMusic;

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

        private void Start()
        {
            GameManager.Instance.OnGameState += HandleGameState;
        }

        private void HandleGameState(GameManager.GameState state)
        {
            switch (state)
            {
                case GameManager.GameState.MainMenu:
                    PlayMusic(mainMenuMusic);
                    break;
                case GameManager.GameState.Playing:
                    PlayMusic(gamePlayMusic);
                    break;
                case GameManager.GameState.Paused:
                    break;
                case GameManager.GameState.GameOver:
                    break;
                    
            }
        }

        void PlayMusic(AudioClip clip)
        {
            musicSource.clip = clip;
            musicSource.Play();
        }

       
    }
