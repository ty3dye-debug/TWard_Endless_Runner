using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UserInterfaceManager : MonoBehaviour
{
    public static UserInterfaceManager Instance;

    [SerializeField] private TextMeshProUGUI scoreDisplay;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject gameOver;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void Start()
    {
        GameOverDisplay();
    }

    private void OnGUI()
    {
        scoreDisplay.text = GameManager.Instance.ScoreDisplay();
    }

    public void GameOverDisplay()
    {
        /*  if (gameOverPanel.activeSelf == true)
          {
              gameOverPanel.SetActive(false);
          }
          else
          {
              gameOverPanel.SetActive(true);
          }*/

        Debug.Log(gameOverPanel.name);
    }
}
