using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObstacle : MonoBehaviour
{

    [SerializeField] private float leftBound = -40f;
    [SerializeField] private float rightBound = 40f;
    

    void Update()
    {
      
        if(transform.position.x < leftBound)
        {
            if(GameManager.Instance.activeObstacles.Contains(this.gameObject))
            {
                GameManager.Instance.activeObstacles.Remove(this.gameObject);
            }
            Destroy(gameObject);
        }

        if(transform.position.x > rightBound)
        {
            Destroy(gameObject);
        }
    }
}
