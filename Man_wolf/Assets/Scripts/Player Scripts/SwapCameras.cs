using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapCameras : MonoBehaviour
{
    private bool isInFirstPerson = true;
    public GameObject firstPersonCamera;
    public GameObject thirdPersonCamera;
    public GameObject thirdPersonModel;
    public KeyCode swapCameraKey = KeyCode.F;

    private void Start()
    {
        thirdPersonCamera.SetActive(false);
        thirdPersonModel.SetActive(false);
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
                thirdPersonModel.SetActive(false);

            }       
             //Third Person
             else
             {
                isInFirstPerson = false;
                firstPersonCamera.SetActive(false);
                thirdPersonModel.SetActive(true);
                thirdPersonCamera.SetActive(true);
            }
        }
    }
}
