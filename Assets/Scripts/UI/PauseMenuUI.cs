using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    void Start()
    {
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.Pause();
        }
    }

    private void OnEnable()
    {
        GameManager.Instance.OnGameState += StateChange;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnGameState -= StateChange;
    }

    private void StateChange(GameManager.GameState state)
    {
        if (state == GameManager.GameState.Paused)
        {
            pauseMenu.SetActive(true);
        }
        else
        {
            pauseMenu.SetActive(false);
        }
    }
}
