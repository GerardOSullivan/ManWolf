using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprintAndCrouch : MonoBehaviour
{
    private PlayerMovement playerMovement;

    public float sprintSpeed = 10f;
    public float moveSpeed = 5f;
    public float crouchSpeed = 2f;

    private Transform look_Root;
    private float standHeight = 1.6f;
    private float crouchHeight = 1f;

    public static bool isCrouching;
    public static bool isRunning;

    private PlayerFootSteps player_Footsteps;

    private float sprintVolume = 0.7f;
    private float crouchVolume = 0.1f;
    private float walkVolumeMin = 0.2f;
    private float walkVolumeMax = 0.6f;

    private float walkStepDistance = 0.6f;
    private float sprintStepDistance = 0.3f;
    private float crouchStepDistance = 0.5f;

    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();

        look_Root = transform.GetChild(0);

        player_Footsteps = GetComponentInChildren<PlayerFootSteps>();
    }

    private void Start()
    {
        player_Footsteps.volume_Min = walkVolumeMin;
        player_Footsteps.volume_Max = walkVolumeMax;
        player_Footsteps.step_distance = walkStepDistance;
    }

    // Update is called once per frame
    void Update()
    {
        Sprint();
        Crouch();
    }

    void Sprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isCrouching)
        {
            isRunning = true;
            playerMovement.speed = sprintSpeed;

            player_Footsteps.step_distance = sprintStepDistance;
            player_Footsteps.volume_Min = sprintVolume;
            player_Footsteps.volume_Max = sprintVolume;
        }

        if(Input.GetKeyUp(KeyCode.LeftShift) && !isCrouching)
        {
            isRunning = false;
            playerMovement.speed = moveSpeed;

            player_Footsteps.volume_Min = walkVolumeMin;
            player_Footsteps.volume_Max = walkVolumeMax;
            player_Footsteps.step_distance = walkStepDistance;
        }
    }

    void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            //if we are crouching - stand up 
            if(isCrouching)
            {
                look_Root.localPosition = new Vector3(0f, standHeight, 0f);
                playerMovement.speed = moveSpeed;

                player_Footsteps.volume_Min = walkVolumeMin;
                player_Footsteps.volume_Max = walkVolumeMax;
                player_Footsteps.step_distance = walkStepDistance;

                isCrouching = false;

            }
            //if we are standing up - crouch
            else
            {
                look_Root.localPosition = new Vector3(0f, crouchHeight, 0f);
                playerMovement.speed = crouchSpeed;

                player_Footsteps.step_distance = crouchStepDistance;
                player_Footsteps.volume_Min = crouchVolume;
                player_Footsteps.volume_Max = crouchVolume;

                isCrouching = true;
            }
        }
    }
}
