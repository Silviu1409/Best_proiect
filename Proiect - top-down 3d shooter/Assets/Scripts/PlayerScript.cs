using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    [Range(5f, 15f)]
    float movementSpeed = 5f;    //viteza de deplasare a playerului

    Rigidbody rb;                //componenta Rigidbody a playerului

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        HandleReset();
    }

    void FixedUpdate()
    {
        HandleMovementInput();
    }

    //functia de deplasare a playerului, folosind arrow keys/wasd
    void HandleMovementInput()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //deplasarea se face folosind componenta de rigidbody
        rb.velocity = new Vector3(h, rb.velocity.y, v) * movementSpeed;
    }

    //functia cu ajutorul careia playerul isi da reset la pozitia de start a jocului
    void HandleReset()
    {
        if (Input.GetKey(KeyCode.R))
        {
            transform.position = new Vector3(0, 1f, 0);
        }
    }
}
