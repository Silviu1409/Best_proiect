using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [Range(2f, 5f)]
    public float movementSpeed = 2f;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;


    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        //metoda de test pt luat damage
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        //daca se atinge playerul de inamic ia damage - pt test
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "PlayerGun")
        {
            TakeDamage(40);
        }
    }


    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
