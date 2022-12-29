using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1AnimationController : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    Enemy1Script enemy1;

    void Start()
    {
        animator = GetComponent<Animator>();
        enemy1 = gameObject.GetComponent("Enemy1Script") as Enemy1Script;
    }

    // Update is called once per frame
    void Update()
    {
        HandleAnimationInput();
    }

    void HandleAnimationInput()
    {
        animator.SetBool("isClose", Enemy1Script.isClose());
        animator.SetBool("isDead", enemy1.isDead());
        
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