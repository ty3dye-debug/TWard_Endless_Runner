using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    [SerializeField] private GameObject obstacle;
    [SerializeField] private float obstacleSpeed = 3f;


    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.P))
        {
            Spawn();
        }
    }


    private void SpawnLoop()
    {

    }

    private void Spawn()
    {
        GameObject spawnedObstacle = Instantiate(obstacle, transform.position, Quaternion.identity);
        
        Rigidbody2D obstacleRB = spawnedObstacle.GetComponent<Rigidbody2D>();

        obstacleRB.velocity = Vector2.left * obstacleSpeed;
    }
}
