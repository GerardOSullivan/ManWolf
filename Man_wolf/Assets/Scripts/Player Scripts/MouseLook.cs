using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform playerRoot;
    public Transform lookRoot;

    [SerializeField]
    private bool invert=false;

    //private bool can_Unlock = true;

    private float sensitivity = 5f;

    //private int smooth_Steps = 10;

    //private float smooth_Weight = 0.4f;

    [SerializeField]
    private float roll_Angle = 0f;

    [SerializeField]
    private float roll_Speed = 3f;

    [SerializeField]
    private Vector2 default_Look_Limits = new Vector2(-70f, 80f);

    private Vector2 look_Angles;

    private Vector2 current_Mouse_look;
    private Vector2 smooth_Move;

    private float current_Roll_Angle;

    private int last_Look_Frame;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        LockAndUnlockCursor();

        if(Cursor.lockState == CursorLockMode.Locked)
        {
            lookAround();
        }
    }

    // This Method locks and unlocks the cursor when escaped is pressed this allows the user to select menus in the escape option
    // This Method could also be used for an inventory system like tab by just changing the KeyCode.Escape to .Tab
    public static void LockAndUnlockCursor()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

    void lookAround()
    {
        current_Mouse_look = new Vector2(
            Input.GetAxis(MouseAxis.MOUSE_Y), Input.GetAxis(MouseAxis.MOUSE_X));

        look_Angles.x += current_Mouse_look.x * sensitivity * (invert ? 1f : -1f); //Turnary opperator in use 'or if and then statements'.
        look_Angles.y += current_Mouse_look.y * sensitivity;

        look_Angles.x = Mathf.Clamp(look_Angles.x, default_Look_Limits.x, default_Look_Limits.y); //wont allow view to go beyond default look limits

        current_Roll_Angle = Mathf.Lerp(current_Roll_Angle, Input.GetAxisRaw(MouseAxis.MOUSE_X)
            * roll_Angle, Time.deltaTime * roll_Speed); //The lerp allows the angle go from a-b in a certain time so the A angle is current angle B is the MouseAxis x and the time is the Delta Time

        lookRoot.localRotation = Quaternion.Euler(look_Angles.x, 0f, current_Roll_Angle);// This moves the parameter of rotation on the X axis on the lookRoot to move the camera
        playerRoot.localRotation = Quaternion.Euler(0f, look_Angles.y, 0f);// This moves the parameter of rotation on the y axis on the player Root to move the camera
    }
}
