using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    public float damage;
    public float healing;


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


    private void OnTriggerEnter2D(Collider2D collision) //How you die, that's it
    {
        if (collision.gameObject.GetComponent<NULL>() || collision.gameObject.GetComponent<NULL>() && isAlive == true)
        {
            DamageHealth();
            GameManager.Instance.playerLives--;
            GameManager.Instance.GameOverCheck();
        }
    }
}

