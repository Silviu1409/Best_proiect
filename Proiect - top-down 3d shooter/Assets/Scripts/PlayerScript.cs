using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Range(2f, 5f)]
    public float movementSpeed = 2f;

    void Start()
    {
        
    }

    void Update()
    {
        HandleMovementInput();
        HandleReset();
    }

    void HandleMovementInput()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 _movement = new Vector3(h, 0, v);
        transform.Translate(_movement * movementSpeed * Time.deltaTime, Space.World);
    }

    void HandleReset()
    {
        if (Input.GetKey(KeyCode.R))
        {
            transform.position = new Vector3(0, 1f, 0);
        }
    }
}
