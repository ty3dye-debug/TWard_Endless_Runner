using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject player;

    public bool isPlaying = false;

    public float currentScore = 0;
    public float currentCollected = 0;

    public List<GameObject> activeObstacles = new List<GameObject>();

    public float currentObstcleSpeed;
    public float maxObstacleSpeed;

    public bool canSpawn = true;

    public PlayerHealth currentHealth;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        isPlaying = false;
    }

    void Update()
    {
        if (isPlaying)
        {
            currentScore += Time.deltaTime;
            Debug.Log("Score ticking: " + currentScore);

            if (Input.GetKeyDown(KeyCode.R))
                ResetGame();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            ResetGame();
            UIManager.Instance.HideGameOver();
            UIManager.Instance.ShowTitleScreen();
        }
    }

    public string ScoreDisplay()
    {
        return Mathf.RoundToInt(currentScore).ToString();
    }

    public void GameOver()
    {
        isPlaying = false;
        PauseObstacles();
        UIManager.Instance.ShowGameOver();
    }

    public void GameOverCheck()
    {
        if (PlayerHealth.Instance.currentHealth <= 0)
            GameOver();
    }

    public void ResetGame()
    {
        isPlaying = false;
        currentScore = 0;
        currentCollected = 0;

        player.SetActive(true);

        foreach (GameObject obstacle in activeObstacles)
            Destroy(obstacle);

        activeObstacles.Clear();
        ResumeObstacles();
    }

    public void PauseObstacles()
    {
        foreach (GameObject obstacle in activeObstacles)
        {
            Rigidbody2D rb = obstacle.GetComponent<Rigidbody2D>();
            if (rb != null)
                rb.velocity = Vector2.zero;
        }

        canSpawn = false;
    }

    public void ResumeObstacles()
    {
        foreach (GameObject obstacle in activeObstacles)
        {
            Rigidbody2D rb = obstacle.GetComponent<Rigidbody2D>();
            if (rb != null)
                rb.velocity = Vector2.left * currentObstcleSpeed;
        }

        canSpawn = true;
    }
}
