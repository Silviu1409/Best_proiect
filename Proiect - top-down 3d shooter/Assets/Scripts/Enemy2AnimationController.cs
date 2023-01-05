using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2AnimationController : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    Enemy2Script enemy2;


    void Start()
    {
        animator = GetComponent<Animator>();
        enemy2 = gameObject.GetComponent("Enemy2Script") as Enemy2Script;
    }

    // Update is called once per frame
    void Update()
    {
        HandleAnimationInput();
    }

    void HandleAnimationInput()
    {
        animator.SetBool("isClose", Enemy2Script.isClose());
        animator.SetBool("isDead", enemy2.isDead());
        
        if (animator.GetBool("isDead") == true)
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isClose", false);
        }   
        else 
        {
        if (animator.GetBool("isClose") == false)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        } 
        }
    }
}