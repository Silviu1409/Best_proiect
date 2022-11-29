using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class AnimationController : MonoBehaviour
{
    [SerializeField]
    Animator animator;              //player's animator

    [SerializeField]
    GameObject gun;                 //player's gun

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
        // The player can't move while it's shooting/reloading
        if (animator.GetBool("isReloading") == false && animator.GetBool("isShooting") == false)
        {
            if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d") || Input.GetKey("up") || Input.GetKey("down") || Input.GetKey("left") || Input.GetKey("right"))
            {
                animator.SetBool("isRunning", true);
            }
            else
            {
                animator.SetBool("isRunning", false);
            }
        }

        // The player can't shoot with no bullets left in round and while it's reloading/jumping or running
        if (Input.GetMouseButton(0) && PlayerScript.noOfBulletsInRound > 0 && animator.GetBool("isReloading") == false && animator.GetBool("isJumping") == false && animator.GetBool("isRunning") == false)
        {
            animator.SetBool("isShooting", true);
        }
        else
        {
            animator.SetBool("isShooting", false);
        }

        // The player is jumping when the ground check says that the player is not on the ground
        animator.SetBool("isJumping", !PlayerScript.getGrounded());
        
    }
}
