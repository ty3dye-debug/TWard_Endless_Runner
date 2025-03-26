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

    void Update()
    {
        if(Input.GetKeyDown("j"))
        {
            ResetGame();
        }
    }

    public void ResetGame()
    {
        isPlaying = false;
        currentScore = 0;
        player.SetActive(true);
        currentCollected = 0;
    }
}
