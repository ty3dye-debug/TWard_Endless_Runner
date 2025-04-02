using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
    
{

    [SerializeField] private Rigidbody2D playerRB;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float jumpTime = 0.3f;
    [SerializeField] private Transform feetPos;  //where the feet at?
    [SerializeField] private LayerMask groundLayer; //what layer of objects as the ground?
    private bool onGround;
    private bool isJumping;
    private float jumpTimer;

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Physics2D.OverlapCircle(feetPos.position,0.25f,groundLayer) == true)
        {
            onGround = true;
        }
        else
        {
            onGround = false;
        }


       if (Input.GetButton("Jump") && onGround == true)
        {
            playerRB.velocity = Vector2.up * jumpForce;
            isJumping = true;
        }

       if(isJumping && Input.GetButton("Jump"))
        {
            if(jumpTimer < jumpTime)
            {
                playerRB.velocity = Vector2.up * jumpForce;
                jumpTimer += Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

       if(Input.GetButtonUp("Jump"))
        {
            isJumping = false;
            jumpTimer = 0f;
        }

        if (Input.GetButtonDown("Fire2"))
        {
            GameManager.Instance.PauseObstacles();
        }

        if (Input.GetButtonUp("Fire2"))
        {
            GameManager.Instance.ResumeObstacles();
        }

    }
}
