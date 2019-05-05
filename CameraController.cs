using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private float lookSpeedH = 2f;      //how quickly holding right mouse moves angle
    private float lookSpeedV = 2f;
    private float zoomSpeed = 1f;       //how quickly up and down will zoom in
    private float dragSpeed = 15f;
    private float yaw = 180f;     // variables used to control the angle at which camera rotates
    private float pitch = 25f;
    public new GameObject camera;
    private Vector3 originalCameraPos;
    private Quaternion originalCameraRot;
    private void Start()                    //saves original position of camera for reset purposes
    {
        originalCameraPos = camera.transform.position;
        originalCameraRot = camera.transform.rotation;
    }
    void Update()
    {
        //Look around with Right Mouse
        if (Input.GetMouseButton(1))
        {
            changeViewAngle();      //if right mouse held, calls function
        }

        if (Input.GetKey(KeyCode.W))
        {
            cameraMovement(0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            cameraMovement(1);  
        }
        if (Input.GetKey(KeyCode.A))
        {
            cameraMovement(2);
        }
        if (Input.GetKey(KeyCode.D))
        {
            cameraMovement(3);
        }

        transform.Translate(0, 0, Input.GetAxis("Mouse ScrollWheel") * zoomSpeed, Space.Self); //uses mousewheel to scroll.

        if (Input.GetKey(KeyCode.R))
        {
            camera.transform.position = originalCameraPos;
            camera.transform.rotation = originalCameraRot;
            yaw = 180f;
            pitch = 25f;
        }
    }
    void changeViewAngle()
    {
        yaw += lookSpeedH * Input.GetAxis("Mouse X");   //changes x rotation of camera.
        pitch -= lookSpeedV * Input.GetAxis("Mouse Y"); //changes y rotation camera.

        transform.eulerAngles = new Vector3(pitch, yaw, 0f);    //changes rotation to vector of pitch and yaw, z axis unaffected.
    }

    // Moves camera according to buttons being pressed
    //
    // @param - int x flags which type of camera movement it is
    private void cameraMovement(int x)
    {
        if (x == 0)
        {
            transform.Translate(0, 0, zoomSpeed, Space.Self);   //changes z axis to zoom in based on itself.
        }
        if (x == 1)
        {
            transform.Translate(0, 0, -zoomSpeed, Space.Self);  //changes z axis to -speed based on itself.
        }
        if (x == 2)
        {
            transform.Translate(-Time.deltaTime * dragSpeed, 0, 0);     //function to move left based on speed.
        }
        if (x == 3)
        {
            transform.Translate(Time.deltaTime * dragSpeed, 0, 0);      //function to move right based on time.
        }
    }
}