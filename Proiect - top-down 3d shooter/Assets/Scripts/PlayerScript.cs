using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    [Range(0f, 15f)]
    float movementSpeed = 1f;               //player's movement speed

    [SerializeField]
    [Range(1f, 10f)]
    float jumpForce = 1f;                   //player's jump force

    bool isGrounded;                        //is player on the ground or not
    Rigidbody rb;                           //player rigidbody

    [SerializeField]
    LayerMask groundLayer;                  //layer to be detected as ground

    [SerializeField]
    [Range(1f, 2f)]
    float groundDistance = 1f;              //distance from player body to ground

    public static int noOfBulletsInRound;   //number of bullets in the gun's round
    int noOfBullets;                        //number of bullets left besides the ones in the gun
    int maxNoOfBulletsInRound;              //the maximum number of bullets that a round can have

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //Set the bullet bounds
        noOfBullets = 50;
        noOfBulletsInRound = 10;
        maxNoOfBulletsInRound = 10;
    }

    void Update()
    {
        HandleReset();

        //Ground Check
        isGrounded = Physics.CheckSphere(transform.position, groundDistance, groundLayer);

        HandleJump();
        HandleShootInput();
        HandleReloadInput();

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

        rb.velocity = new Vector3(h * movementSpeed, rb.velocity.y, v * movementSpeed);
        rb.velocity.Normalize();
    }

    //Player jump
    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
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
        if (Input.GetMouseButton(0))
        {
            GunScript.Instance.Shoot();
        }
    }

    //Rotate player with gun barrel 
    void HandleRotationInput()
    {
        RaycastHit _hit;
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(_ray, out _hit))
        {
            transform.LookAt(new Vector3(_hit.point.x, transform.position.y, _hit.point.z));
        }
    }

    //Player reloads the gun
    async void HandleReloadInput()
    {
        if (Input.GetKey(KeyCode.R) && noOfBullets > 0)
        {
            await Task.Delay(1500);     //add delay of 1.5s to reload task

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
        }
    }
}