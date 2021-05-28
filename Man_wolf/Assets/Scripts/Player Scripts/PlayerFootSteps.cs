using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootSteps : MonoBehaviour
{
    private AudioSource footstep_Sound;

    [SerializeField]
    private AudioClip[] footstep_Clip;

    private CharacterController character_Controller;

    [HideInInspector]
    public float volume_Min, volume_Max;

    private float accumulated_Distance;

    [HideInInspector]
    public float step_distance;

    private void Awake()
    {
        footstep_Sound = GetComponent<AudioSource>();

        character_Controller = GetComponentInParent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckToPlayFootstepSound();
    }

    void CheckToPlayFootstepSound()
    {

        //if we are NOT on the ground return
        if(!character_Controller.isGrounded)
        {
            return;
        }


        // sqrMagnitude checks the length so it checks if velocity is > 0 so if moving it is so will be true
        if (character_Controller.velocity.sqrMagnitude > 0) 
        {

            //accumulated distance is the value of how far we can go
            //e.g make a step or sprint, or move while crouching 
            //until we play the footstep sound

            accumulated_Distance += Time.deltaTime;

            if (accumulated_Distance > step_distance)
            {
                //This was causing an error only because there was no audio attached. Uncomment when audio attached
               // footstep_Sound.volume = Random.Range(volume_Min, volume_Max);
               // footstep_Sound.clip = footstep_Clip[Random.Range(0, footstep_Clip.Length)];
               // footstep_Sound.Play();

                accumulated_Distance = 0f;
            }
        }

        else
        {
            accumulated_Distance = 0f;
        }
    }
}
