using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    [SerializeField]
    GameObject gun;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        HandleAnimationInput();
    }

    void HandleAnimationInput()
    {
        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d") || Input.GetKey("up") || Input.GetKey("down") || Input.GetKey("left") || Input.GetKey("right"))
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if (Input.GetMouseButton(0) && PlayerScript.noOfBulletsInRound > 0)
        {
            animator.SetBool("isShooting", true);
            gun.SetActive(true);
        }
        else
        {
            animator.SetBool("isShooting", false);
            gun.SetActive(false);
        }

        if (Input.GetKey("space"))
        {
            animator.SetBool("isJumping", true);
        }
        else
        {
            animator.SetBool("isJumping", false);
        }


        if (Input.GetKey("r"))
        {
            animator.SetBool("isReloading", true);
        }
        else
        {
            animator.SetBool("isReloading", false);
        }
    }
}
