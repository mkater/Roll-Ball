using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    private GameObject gameObjectName;
    private Vector3 originalPos;
    private Quaternion originalRotation;


    private bool selectedObject = false;
    private float rayLength = 500f;
    private string objectName;
    private string rotateX = "RotateX";
    private string rotateY = "RotateY";
    private string rotateZ = "RotateZ";
    private float moveVertical;
    private float moveHorizontal;
    private float moveZAxis;
    private string moveX = "MoveX";
    private string moveY = "MoveY";
    private string moveZ = "MoveZ";
    private bool playMode;

   
    private void Update()
    {
        playMode = GameObject.Find("GameController").GetComponent<GameControllerScript>().gamePlay; // GameControllerScript flags the begining of play mode. 
    }

    private void FixedUpdate()
    {
        playMode = GameObject.Find("GameController").GetComponent<GameControllerScript>().gamePlay; // GameControllerScript flags the begining of play mode.
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);    //make gameplay true when clicked for that object.
            if (Physics.Raycast(ray, out hit, rayLength))
            {
                objectName = hit.collider.name; // grabs object intercepted by the raycast


                // checks for children objects of sramp & 2nd sramp
                if (objectName == "base" || objectName == "base (1)" || objectName == "base (2)" || objectName == "Cube" || objectName == "Cube (1)" || objectName == "Cube (2)" || objectName == "Cube (3)" || objectName == "Cube (4)" || objectName == "Cube (5)")
                {
                    objectName = "sramp";
                }
                if (objectName == "base2" || objectName == "base2 (1)" || objectName == "base2 (2)" || objectName == "Cube2" || objectName == "Cube2 (1)" || objectName == "Cube2 (2)" || objectName == "Cube2 (3)" || objectName == "Cube2 (4)" || objectName == "Cube2 (5)")
                {
                    objectName = "sramp2";
                }
                gameObjectName = GameObject.Find(objectName); // Set object selected as object of focus
                selectedObject = true; // Set object to be moveable
            }
        }
        // Check if object is moveable
        if (selectedObject == true)
        {
            rotate(gameObjectName); // Rotates Object
            Mover(gameObjectName); // Moves Object
        }
    }

    void Mover(GameObject objectName)
    {

         moveVertical = Input.GetAxis("Vertical");
         moveHorizontal = Input.GetAxis("Horizontal");
         moveZAxis = Input.GetAxis("MoveZ");

        if (Input.GetButton(moveX) && playMode == false && selectedObject == true) // if playMode == false then the game has begun. All movement is disabled.
        {
            if (Input.GetButton(moveX))
            {
               objectName.transform.Translate(moveHorizontal, 0f, 0f, Space.World);
            }
        }
        if (Input.GetButton(moveY) && playMode == false && selectedObject == true) // if playMode == false then the game has begun. All movement is disabled.
        {
            if (Input.GetButton(moveY)) // Moves in negative direction
            {
                objectName.transform.Translate(0f, moveVertical, 0f, Space.World);
            }
        }
        if (Input.GetButton(moveZ) && playMode == false && selectedObject == true) // if playMode == false then the game has begun. All movement is disabled.
        {
            if (Input.GetButton(moveZ)) // Moves in negative direction
            {
                objectName.transform.Translate(0f, 0f, moveZAxis, Space.World);
            }
        }
    }

    // Rotates Ramp according to button being pressed
    private void rotate(GameObject objectName)
    {
        if (Input.GetButton(rotateX) && playMode == false && selectedObject == true) // if playMode == false then the game has begun. All movement is disabled.
        {
            objectName.transform.Rotate(1f, 0f, 0f, Space.World); // Rotates ramp on the x axis
        }
        if (Input.GetButton(rotateY) && playMode == false && selectedObject == true) // if playMode == false then the game has begun. All movement is disabled.
        {
            objectName.transform.Rotate(0f, 1f, 0f, Space.World); // Rotates ramp on the y axis
        }
        if (Input.GetButton(rotateZ) && playMode == false && selectedObject == true) // if playMode == false then the game has begun. All movement is disabled.
        {
            objectName.transform.Rotate(0f, 0f, 1f, Space.World); // Rotates ramp on the z axis
        }
    }
}


