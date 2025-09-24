using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;

    private void Start()
    {
        gameOverUI.SetActive(false);
    }

    private void OnEnable()
    {
        GameManager.Instance.OnGameOver += OpenGameOverUI;
    }

    private void OpenGameOverUI()
    {
        gameOverUI.SetActive(true);
    }

    private void OnDisable()
    {
        GameManager.Instance.OnGameOver -= OpenGameOverUI;
    }
}
