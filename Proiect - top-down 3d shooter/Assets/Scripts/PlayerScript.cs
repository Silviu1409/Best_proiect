using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;


public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    [Range(0f, 15f)]
    float movementSpeed = 1f;               //player's movement speed

    [SerializeField]
    [Range(1f, 10f)]
    float jumpForce = 1f;                   //player's jump force

    static bool isGrounded;                 //is player on the ground or not
    Rigidbody rb;                           //player rigidbody

    [SerializeField]
    LayerMask groundLayer;                  //layer to be detected as ground

    [SerializeField]
    [Range(0f, 0.5f)]
    float groundDistance = 0.01f;           //distance from player body to ground

    public static int noOfBulletsInRound;   //number of bullets in the gun's round
    int noOfBullets;                        //number of bullets left besides the ones in the gun
    int maxNoOfBulletsInRound;              //the maximum number of bullets that a round can have

    [SerializeField]
    GameObject gun;                         //player's gun

    [SerializeField]
    Animator animator;                      //player's animator

    int reloadTime;                         //how much it takes(in ms) to reload the gun

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    //public TextMeshProUGUI ammoInGunText;
    //public TextMeshProUGUI ammoLeftText;
    public TextMeshProUGUI ammoText;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        //Set the bullet bounds
        noOfBullets = 50;
        noOfBulletsInRound = 10;
        maxNoOfBulletsInRound = 10;
        reloadTime = 850;

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        //ammoInGunText.text = noOfBullets.ToString();
        //ammoLeftText.text = noOfBulletsInRound.ToString();
        ammoText.text = noOfBulletsInRound.ToString() + "/" + noOfBullets.ToString();
        


    }

    void Update()
    {
        HandleReset();

        //Ground Check
        isGrounded = Physics.CheckSphere(transform.position, groundDistance, groundLayer);
        
        HandleJump();
        HandleShootInput();
        HandleReloadInput();

        //ammoInGunText.text = noOfBullets.ToString();
        //ammoLeftText.text = noOfBulletsInRound.ToString();
        ammoText.text = noOfBulletsInRound.ToString() + "/" + noOfBullets.ToString();


    }

    void FixedUpdate()
    {
        HandleMovementInput();
        HandleRotationInput();
    }

    //Player move
    void HandleMovementInput()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (animator.GetBool("isReloading") == false && animator.GetBool("isShooting") == false)
        {
            rb.velocity = new Vector3(h * movementSpeed, rb.velocity.y, v * movementSpeed);
            rb.velocity.Normalize();
        }
    }

    //Player jump
    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && animator.GetBool("isShooting") == false && animator.GetBool("isReloading") == false)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    //Player reset
    void HandleReset()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            //resets player to the center of the map
            transform.position = new Vector3(0, 1f, 0);
        }
    }

    //Player shoots with gun using left click
    void HandleShootInput()
    {
        if (Input.GetMouseButton(0) && animator.GetBool("isReloading") == false && isGrounded && animator.GetBool("isRunning") == false)
        {
            
            if (gun.transform.position.y >= 2.36)
            { 
                GunScript.Instance.Shoot(); 
            }
        }
    }

    //Rotate player with gun barrel 
    void HandleRotationInput()
    {
        RaycastHit _hit;
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        int layerMask = 1 << LayerMask.NameToLayer("Ground");   //layermask for the ground

        // Apply raycast with a distance of 50, using the ground layermask
        if (Physics.Raycast(_ray, out _hit, 50f, layerMask))
        {
            //Added offset for raycast
            transform.LookAt(new Vector3(_hit.point.x, transform.position.y, _hit.point.z - gameObject.GetComponent<CapsuleCollider>().center.y));
        }
    }

    //Player reloads the gun
    async void HandleReloadInput()
    {
        if (Input.GetKey(KeyCode.R) && noOfBullets > 0 && isGrounded && animator.GetBool("isReloading") == false && animator.GetBool("isShooting") == false && isGrounded && animator.GetBool("isRunning") == false)
        {
            animator.SetBool("isReloading", true);      //now the animator knows that the player is reloading the gun
            
            await Task.Delay((int)(reloadTime * 1/Time.timeScale));     //add delay of 1.5s to reload task

            if (noOfBullets >= maxNoOfBulletsInRound)
            {
                noOfBullets = noOfBullets - maxNoOfBulletsInRound + noOfBulletsInRound;
                noOfBulletsInRound = maxNoOfBulletsInRound;
            }
            else
            {
                int max_bullets = maxNoOfBulletsInRound - noOfBulletsInRound;       //the maximum number of bullets that can be added in the round
                if (noOfBullets <= max_bullets)
                {
                    noOfBulletsInRound += noOfBullets;
                    noOfBullets = 0;
                }
                else
                {
                    noOfBulletsInRound = maxNoOfBulletsInRound;
                    noOfBullets -= max_bullets;
                }
            }

            animator.SetBool("isReloading", false);     //now the animator knows that the player is not reloading the gun
        }
    }

    //Check from other Scripts if Player is grounded
    public static bool getGrounded()
    {
        return isGrounded;
    }

    void OnCollisionEnter(Collision collision)
    {
        //daca se atinge playerul de inamic ia damage - pt test
        if (collision.gameObject.tag == "Enemy1" || collision.gameObject.tag == "Enemy2" || collision.gameObject.tag == "EnemyBullet")
        {
            TakeDamage(30);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

}