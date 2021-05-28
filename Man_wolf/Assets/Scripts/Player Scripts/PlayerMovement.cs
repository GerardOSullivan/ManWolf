using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController character_Controller;
    private Vector3 moveDirection;

    public float speed = 5f;
    public static bool isJumping = false;
    public static bool isWalking = false;
    private float gravity = 20f;

    public float jumpForce = 10f;
    private float verticalVelocity;

    private void Awake()
    {
        character_Controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        MoveThePlayer();
    }

    void MoveThePlayer()
    {
        moveDirection = new Vector3(Input.GetAxis(Axis.HORIZONTAL), 0f,
                                    Input.GetAxis(Axis.VERTICAL));

        //horizontal is A and D keys. A will have a negative value and D will be positve e.g -0.5 is an A press moving left
        //Vertical is W and S keys. 

        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed * Time.deltaTime;
        //deltatime is done in frames 
        //multiplies the speed to the current direction to increase value

        ApplyGravity();
        character_Controller.Move(moveDirection);
        isWalking = true;

    }// move the player :)

    void ApplyGravity()
    {
       
            verticalVelocity -= gravity * Time.deltaTime;

            //Jump
            PlayerJump();
        

        moveDirection.y = verticalVelocity *Time.deltaTime;
    }

    void PlayerJump()
    {
        if(character_Controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            verticalVelocity = jumpForce;
        }
        else
        {
            isJumping = false;
        }
    }
}
