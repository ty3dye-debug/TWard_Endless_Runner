using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
    
{

    [SerializeField] private Rigidbody2D playerRB;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float jumpTime = 0.3f;
    [SerializeField] private float slamFallSpeed = 20f;
    [SerializeField] private float rollDuration = 2f;
    [SerializeField] private float rollCooldown = 5f;
    [SerializeField] private SpriteRenderer playerSprite; // Could also use animator
    [SerializeField] private Sprite rollSprite;
    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Transform feetPos;  //where the feet at?
    [SerializeField] private LayerMask groundLayer; //what layer of objects as the ground?
    private bool onGround;
    private bool isJumping;
    private bool hasJumped;
    private bool slamFalling;
    private bool isRolling = false;
    private bool canSlam = true;
    private float rollTimer = 0f;
    private float cooldownTimer = 0f;
    private float jumpTimer;
    

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Physics2D.OverlapCircle(feetPos.position,0.25f,groundLayer) == true)
        {
            if (!onGround && slamFalling && canSlam)
            {
                StartRoll();
            }

            onGround = true;
            hasJumped = false;
            slamFalling = false;
        }
        else
        {
            onGround = false;
        }

       //Jumping
       if (Input.GetButton("Jump") && onGround == true)
        {
            playerRB.velocity = Vector2.up * jumpForce;
            isJumping = true;
            hasJumped = true;
            jumpTimer = 0f;
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

        //Slam Falling
        if (hasJumped && !onGround && Input.GetButtonDown("Jump") && !slamFalling)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, -slamFallSpeed);
            slamFalling = true;
        }

        // Roll Timer
        if (isRolling)
        {
            rollTimer -= Time.deltaTime;
            if (rollTimer <= 0f)
            {
                EndRoll();
            }
        }

        // Cooldown
        if (!canSlam)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0f)
            {
                canSlam = true;
            }
        }

        //ROLLING CODE

        void StartRoll()
        {
            isRolling = true;
            canSlam = false;
            rollTimer = rollDuration;
            cooldownTimer = rollCooldown;

            // Swap
            if(playerSprite.sprite != null) playerSprite.sprite = rollSprite;


            // Disable obstacle collisions
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Obstacle"), true);
        }

        void EndRoll()
        {
            isRolling = false;

            // Revert Swap
            playerSprite.sprite = normalSprite;

            // Turn on collisions
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Obstacle"), false);
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
