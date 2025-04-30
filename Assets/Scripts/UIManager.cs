using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
//using System.Runtime.CompilerServices;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private TextMeshProUGUI scoreDisplay;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject titleScreen;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject); // Prevent duplicate instances

        HideGameOver();
        ShowTitleScreen();
        Debug.Log("Awake: Hiding game over and showing title screen");
        Debug.Log("gameOverPanel active? " + gameOverPanel.activeSelf);
    }

    private void Start()
    {
        Debug.Log("Start: Forcing title screen ON and game over panel OFF");
        HideGameOver();
        ShowTitleScreen();

        Debug.Log("Title screen active: " + titleScreen.activeSelf);
        Debug.Log("Game over panel active: " + gameOverPanel.activeSelf);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Z pressed - trying to start game");

            UIManager.Instance.HideGameOver();
            UIManager.Instance.HideTitleScreen();

            GameManager.Instance.isPlaying = true;
            Debug.Log("isPlaying set to: " + GameManager.Instance.isPlaying);

            GameManager.Instance.ResetGame();
        }

        if (gameOverPanel.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                HideGameOver();
                ShowTitleScreen();
            }
        }
    }

    private void OnGUI()
    {
        scoreDisplay.text = GameManager.Instance.ScoreDisplay();
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void HideGameOver()
    {
        gameOverPanel.SetActive(false);
    }

    public void ShowTitleScreen()
    {
        titleScreen.SetActive(true);
    }

    public void HideTitleScreen()
    {
        titleScreen.SetActive(false);
    }
}