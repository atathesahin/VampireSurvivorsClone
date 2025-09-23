using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        
        public float inGameTime;
        
        #region GameState
        
        public enum GameState
        {
            MainMenu,
            Playing,
            Paused,
            GameOver
        }
        public GameState gameState;
        
        #endregion
        #region Events

        public event Action<GameState> OnGameState;
        public event Action OnGameStart;
        public event Action OnGameOver;
        public event Action<float> OnTimeUpdate;
    
        #endregion
        
        
        #region Singleton
        private void Awake()
        {
            if (Instance == null)
            {
                Instance=this;
                DontDestroyOnLoad(gameObject);
            }
            else
                Destroy(gameObject);
        }
        
        #endregion 

        private void Start()
        {
            SwitchState(GameState.MainMenu);
        }

        private void Update()
        {
            if (gameState == GameState.Playing)
            {
                inGameTime += Time.deltaTime;
                OnTimeUpdate?.Invoke(inGameTime);
            }
        }

        private void SwitchState(GameState newState)
        {
            if (gameState == newState) return;
            
            gameState = newState;
            OnGameState?.Invoke(gameState);
        }
        
        public void SelectLevel(string mapName)
        {
            inGameTime = 0;
            Time.timeScale = 1;
            SwitchState(GameState.Playing);
            OnGameStart?.Invoke();
            SceneManager.LoadScene(mapName);
        }
        public void GameOver()
        {
            if (gameState != GameState.Playing) return;
            
            SwitchState(GameState.GameOver);
            OnGameOver?.Invoke();
        }
        public void ReturnToMainMenu()
        {
            SwitchState(GameState.MainMenu);
            SceneManager.LoadScene("MainMenu");
        }
        public void Pause()
        {

            if (gameState == GameState.Playing)
            {
                Time.timeScale = 0;
                SwitchState(GameState.Paused);
            }
            else if (gameState == GameState.Paused)
            {
                Time.timeScale = 1;
                SwitchState(GameState.Playing);
            }
     
        }
        public void QuitGame()
        {
            Application.Quit();
        }
        

        
    }
