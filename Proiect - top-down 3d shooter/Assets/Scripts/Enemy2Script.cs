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

    // Start is called before the first frame update
    void Start()
    {
        
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
}
