using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Script : MonoBehaviour
{
    [SerializeField]
    Transform target;                       // target object 

    [SerializeField]
    float movementSpeed = 2f;               // enemy movement speed

    static float distanceToPlayer = 10.0f;          // distance between enemy and target

    [SerializeField]
    Animator animator;

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, target.position);
        MoveEnemy();
        if (distanceToPlayer < 10.0f)
        {
            EnemyGunScript.Instance.Shoot();                // bug la shooting
        }
    }

    void MoveEnemy()
    {
        RotateEnemy();
        if (isClose() == false)
        {
            transform.position += transform.forward * movementSpeed * Time.deltaTime;       // chasing the target
        }
        else
        {
            transform.position += new Vector3(0, 0, 0);
        }
    }
    
    void RotateEnemy()
    {
        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));         // rotate enemy to face the target 
    }

    public static bool isClose()
    {
        if (distanceToPlayer < 10.0f)
            return true;
        else
            return false;
    }

    void OnCollisionEnter(Collision collision)
    {
        //daca se atinge playerul de inamic ia damage - pt test
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "PlayerBullet")
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
