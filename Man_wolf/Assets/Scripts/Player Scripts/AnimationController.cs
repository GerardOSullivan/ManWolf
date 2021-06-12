using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //animation for running
        if(PlayerSprintAndCrouch.isRunning)
        {
            animator.SetBool("IsRunning",true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }

        //animation for jumping
        if(PlayerMovement.isJumping)
        {
            animator.SetBool("IsJumping", true);
        }
        else
        {
           animator.SetBool("IsJumping", false);
        }

        //animation for walking 
        if(Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }

        //animation for crouching
        if (PlayerSprintAndCrouch.isCrouching)
        {
            animator.SetBool("IsCrouching", true);
        }
        else
        {
            animator.SetBool("IsCrouching", false);
        }


    }
}
