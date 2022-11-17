using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    [Range(0f, 15f)]
    float movementSpeed = 1f;    //player's movement speed

    [SerializeField]
    [Range(1f, 10f)]
    float jumpForce = 1f;        //player's jump force

    bool isGrounded;             //is player on the ground or not
    Rigidbody rb;               //player rigidbody

    [SerializeField]
    LayerMask groundLayer;      //layer to be detected as ground

    [SerializeField]
    [Range(1f, 2f)]
    float groundDistance = 1f;  //distance from player body to ground

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        HandleReset();

        //Ground Check
        isGrounded = Physics.CheckSphere(transform.position, groundDistance, groundLayer);

        HandleJump();
        HandleShootInput();
        
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

        Vector3 moveVector = transform.TransformDirection(new Vector3(h, 0f, v)) * movementSpeed;
        rb.velocity = new Vector3(moveVector.x, rb.velocity.y, moveVector.z);
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
        if (Input.GetKeyDown(KeyCode.R))
        {
            //resets player to the center of the map
            transform.position = new Vector3(0, 1f, 0);
        }
    }

    //functia cu ajutorul careia playerul poate trage cu arma la left click
    void HandleShootInput()
    {
        if (Input.GetMouseButton(0))
        {
            GunScript.Instance.Shoot();
        }
    }

    //rotate player with gun barrel 
    void HandleRotationInput()
    {
        RaycastHit _hit;
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _hit))
        {
            transform.LookAt(new Vector3(_hit.point.x, transform.position.y, _hit.point.z));
            
        }
    }
}
