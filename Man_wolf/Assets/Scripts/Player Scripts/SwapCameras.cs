using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapCameras : MonoBehaviour
{
    public static bool isInFirstPerson = true;
    public GameObject firstPersonCamera;
    public GameObject thirdPersonCamera;
    public KeyCode swapCameraKey = KeyCode.Q;

    private void Start()
    {
        thirdPersonCamera.SetActive(false);
        firstPersonCamera.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //firstperson
        if (Input.GetKeyDown(swapCameraKey))
        {
            if(!isInFirstPerson)
            {
                isInFirstPerson = true;
                thirdPersonCamera.SetActive(false);
                firstPersonCamera.SetActive(true);
            }       
             //Third Person
             else
             {
                isInFirstPerson = false;
                firstPersonCamera.SetActive(false);
                thirdPersonCamera.SetActive(true);
             }
        }
    }
}
