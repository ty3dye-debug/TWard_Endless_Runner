using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public GameObject player;

    public bool isPlaying;

    public float currentScore;

    public float currentCollected;

    public List<GameObject> activeObstacles;

    public float currentObstcleSpeed;
    public float maxObstacleSpeed;

    public bool canSpawn = true;

    void Update()
    {
      //SCORE
        if(isPlaying == true)
        {
            currentScore += Time.deltaTime;
        }
      //RESET  
        if(Input.GetKeyDown("r"))
        {
            if(isPlaying == true)
            {
                ResetGame();
            }
            else
            {
                ResetGame();
                UIManager.Instance.GameOverDisplay();
            }
        }
    }

    public string ScoreDisplay()
    {
        return Mathf.RoundToInt(currentScore).ToString();
    }
    
    public void GameOver()
    {
        currentScore = 0;
        isPlaying = false;
        UIManager.Instance.GameOverDisplay();
    }



    public void ResetGame()
    {
        isPlaying = false;
        currentScore = 0;
        player.SetActive(true);
        currentCollected = 0;
        foreach (GameObject go in activeObstacles)
        {
            Destroy(go);
        }
        activeObstacles.Clear();
        ResumeObstacles();
    }

    public void PauseObstacles()
    {
        foreach (GameObject obstacle in activeObstacles)
        {
            Rigidbody2D obstacleRB = obstacle.GetComponent<Rigidbody2D>();
            obstacleRB.velocity = Vector2.left * 0;
        }

        canSpawn = false;
    }

    public void ResumeObstacles()
    {
        foreach (GameObject obstacle in activeObstacles)
        {
            Rigidbody2D obstacleRB = obstacle.GetComponent<Rigidbody2D>();
            obstacleRB.velocity = Vector2.left * currentObstcleSpeed;
        }

        canSpawn = true;
    }
}
