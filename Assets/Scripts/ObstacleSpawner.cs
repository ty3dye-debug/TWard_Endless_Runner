using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    [SerializeField] private List<GameObject> obstaclePrefabs;
    [SerializeField] private float obstacleSpeed = 3f;
    [SerializeField] private float spawnTimeMinimum = 2f;
    [SerializeField] private float spawnTimeMaximum = 5f;

    public float obstacleSpawnTime = 2f;
    private float timeUntilObstacleSpawn;

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.P))
        {
            Spawn();
        }

        SpawnLoop();
    }


    private void SpawnLoop()
    {
        timeUntilObstacleSpawn += Time.deltaTime;

        if(timeUntilObstacleSpawn >= obstacleSpawnTime)
        {
            Spawn();
            obstacleSpawnTime = Random.Range(spawnTimeMinimum, spawnTimeMaximum);
            timeUntilObstacleSpawn = 0f;
        }

    }

    private void Spawn()
    {
        GameObject obstacleSpawn = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Count)];

        GameObject spawnedObstacle = Instantiate(obstacleSpawn, transform.position, Quaternion.identity);
        
        Rigidbody2D obstacleRB = spawnedObstacle.GetComponent<Rigidbody2D>();

        obstacleRB.velocity = Vector2.left * obstacleSpeed;
    }
}
