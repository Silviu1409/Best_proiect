using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Script : MonoBehaviour
{
    [SerializeField]
    Transform target;                       // target object 

    [SerializeField]
    float movementSpeed = 2f;               // enemy movement speed

    static float distanceToPlayer=10.0f;          // distance between enemy and target

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
        distanceToPlayer = Vector3.Distance(transform.position, target.position);
        // Debug.Log(distanceToPlayer);
    }

    void MoveEnemy()
    {
        RotateEnemy();
        transform.position += transform.forward * movementSpeed * Time.deltaTime;       // chasing the target
    }
    
    void RotateEnemy()
    {
        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));         // rotate enemy to face the target
    }

    public static bool isClose()
    {
        if (distanceToPlayer < 5.0f)
            return true;
        else
            return false;
    }

}