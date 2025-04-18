using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance;

    public float maxHealth = 3f;
    public float currentHealth = 3f;

    public float damage = 1f;
    public float healing = 1f;


    private void Start()
    {
        currentHealth = maxHealth;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ApplyHealing();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            DamageHealth();
        }
    }

    void ApplyHealing()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth = currentHealth + healing;
        }
    }

    public void DamageHealth()
    {
        if (currentHealth > 0)
        {
            currentHealth = currentHealth - damage;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Obstacle")
        {
            DamageHealth();
            GameManager.Instance.GameOverCheck();
        }
    }
}

