using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

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

    async void HandleAnimationInput()
    {
        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d") || Input.GetKey("up") || Input.GetKey("down") || Input.GetKey("left") || Input.GetKey("right"))
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if (Input.GetMouseButton(0) && PlayerScript.noOfBulletsInRound > 0 && animator.GetBool("isReloading") == false && animator.GetBool("isJumping") == false)
        {
            animator.SetBool("isShooting", true);
        }
        else
        {
            animator.SetBool("isShooting", false);
        }

        if (Input.GetKey("space") && animator.GetBool("isReloading") == false && animator.GetBool("isShooting") == false)
        {
            animator.SetBool("isJumping", true);
            await Task.Delay(1000);
            animator.SetBool("isJumping", false);
        }
        


        if (Input.GetKey("r") && animator.GetBool("isShooting") == false && animator.GetBool("isJumping") == false)
        {
            animator.SetBool("isReloading", true);
            await Task.Delay(1600);
            animator.SetBool("isReloading", false);
        }
        
    }
}
