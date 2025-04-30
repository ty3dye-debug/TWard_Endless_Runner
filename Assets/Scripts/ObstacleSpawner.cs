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

    public bool canSpawn = true;

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.P))
        {
            Spawn();
        }

        if (GameManager.Instance.isPlaying && GameManager.Instance.canSpawn)
        {
            SpawnLoop();
        }
    }


    private void SpawnLoop()
    {
        timeUntilObstacleSpawn += Time.deltaTime;
        Debug.Log("Spawning loop running...");

        if (timeUntilObstacleSpawn >= obstacleSpawnTime)
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

        GameManager.Instance.currentObstcleSpeed = obstacleSpeed;

        GameManager.Instance.activeObstacles.Add(spawnedObstacle);

        spawnedObstacle.AddComponent<DestroyObstacle>();
    }
}
