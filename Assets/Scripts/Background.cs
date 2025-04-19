using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    private float spriteWidth;
    private Vector3 startPosition;

    //private bool isMoving = true;

    void Start()
    {
        startPosition = transform.position;
        spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        //if (!isMoving) return;

        float newX = Mathf.Repeat(Time.time * moveSpeed, spriteWidth);
        transform.position = startPosition + Vector3.left * newX;
    }

    /*public void PauseBackground()
    {
        isMoving = false;
    }

    public void ResumeBackground()
    {
        isMoving = true;
    }*/
}
