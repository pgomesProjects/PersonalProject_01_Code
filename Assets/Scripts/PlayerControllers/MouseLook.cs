using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controls the camera of the player and how they look around
//Tutorial found from Brackeys YouTube Channel (https://www.youtube.com/watch?v=_QajrabyTJc)

public class MouseLook : MonoBehaviour
{

    //Edit the mouse sensitivity in the Inspector
    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //Makes sure the cursor is locked to the center so that it doesn't move outside of the window
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;

        //This is clamping, which is to basically set a min and max for the rotation allowed for the camera
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Quaternion keeps track of rotation
        //Uses a Euler angle to transform the rotation

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        //Allow the player to look left and right (X axis)
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
