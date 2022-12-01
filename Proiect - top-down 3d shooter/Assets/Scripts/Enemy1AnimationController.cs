using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1AnimationController : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleAnimationInput();
    }

    void HandleAnimationInput()
    {
        animator.SetBool("isClose", Enemy1Script.isClose());
        

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