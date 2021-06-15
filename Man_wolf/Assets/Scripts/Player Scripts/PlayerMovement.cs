using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public Transform mainCamera;

    private float turnSmoothTime = 0.05f;
    private float turnSmoothVelocity;

    private Vector3 moveDirection;
    public float speed = 4f;
    public static bool isJumping = false;
    public static bool isWalking = false;
    private float gravity = 20f;

    public float jumpForce = 10f;
    private float verticalVelocity;

    void Update()
    {
        MoveThePlayer();
    }

    void MoveThePlayer()
    {
        moveDirection = new Vector3(Input.GetAxisRaw(Axis.HORIZONTAL), 0f, Input.GetAxisRaw(Axis.VERTICAL)).normalized;

          //horizontal is A and D keys. A will have a negative value and D will be positve e.g -0.5 is an A press moving left
          //Vertical is W and S keys. 

          if (SwapCameras.isInFirstPerson)
          {
              moveDirection = transform.TransformDirection(moveDirection);
          }
          else
          {
              if (moveDirection.magnitude >= 0.1f)
              {
                  float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg + mainCamera.eulerAngles.y;
                  float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                  transform.rotation = Quaternion.Euler(0f, angle, 0f);
                  moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
              }
          }

            moveDirection *= speed * Time.deltaTime;
            ApplyGravity();
            characterController.Move(moveDirection);
   
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
        if(characterController.isGrounded && Input.GetKeyDown(KeyCode.Space))
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
