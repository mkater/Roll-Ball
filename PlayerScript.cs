using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public int i = 0;
    public bool winGame;
    public bool stuck;
    public bool restartController = false;


    public GameObject s_shape;
    public GameObject teleporter_in;
    public GameObject teleporter_out;
    public GameObject turbo;
    public GameObject jumper;
    public GameObject s_shape2;
    public GameObject teleporter_in2;
    public GameObject teleporter_out2;
    public GameObject turbo2;
    public GameObject jumper2;
    public Text winText;
    public GameObject goal;


    private Rigidbody rb; 
    private Vector3 newPosition;
    private Vector3 currentPosition;
    private Vector3 speedPosition;

    private bool hasTurbo;
    private bool hasJump;
    private bool hasTurbo2;
    private bool hasJump2;
    private bool reachedGoal = false;
    private bool checkReachedGoal = true;
    private bool playMode;
    private float startTime = 7;


    void Start()
    {
        rb = GetComponent<Rigidbody>();     //Ball needs GetComponent to set physics to 0.
        winText.text = " ";
        currentPosition = transform.position;       //saves position of ball for resets.
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            rb.velocity = new Vector3(0, 0);        //ball now has no velocity.  Won't fly forward when game restarts.
            winText.text = "";
        }
    }

    // Update Goal Text
    void SetGoalText()
    {
        winText.text = "You Win!";
        winGame = true;
        goal.SetActive(false);
    }

    private void FixedUpdate()
    {
        playMode = GameObject.Find("GameController").GetComponent<GameControllerScript>().gamePlay; // GameControllerScript flags the begining of play mode.

        restartController = GameObject.Find("GameController").GetComponent<GameControllerScript>().restart; //calling restart bool from gamecontroller script

        if (playMode == true && winGame == false) //only check position movement if game mode is on
        {
            startTime = startTime - 1; // subtract starTime every update.         

            newPosition = transform.position; // update new position

            if (startTime < 0) //only check after start time is less than 0.
            {
                if (newPosition != currentPosition) // if there is movement set text to blank NEED TO SET WINNING FLAG 
                {
                    winText.text = "";
                }
                else
                {
                    winText.text = "You are stuck! "; // if there is no movement display you are stuck message box
                }
                startTime = 7; //reset timer
            }
            currentPosition = transform.position; // update new current position

            // Checks if it can check for reach goal
            if (checkReachedGoal)
            {
                // Checks if goal has been reached and update setgoal text as needed
                reachedGoal = GameObject.Find("Goal").GetComponent<GoalScript>().winner;
                if (reachedGoal)
                {
                    SetGoalText();
                    checkReachedGoal = false;
                }
            }

            // Check if objects are active before checking if they have been triggered
            if (turbo.activeSelf )
            {
                hasTurbo = GameObject.Find("TurboSpeed").GetComponent<TurboSpeed>().hasTurbo;
            }
            if (turbo2.activeSelf)
            {
                hasTurbo2 = GameObject.Find("TurboSpeed2").GetComponent<TurboSpeed>().hasTurbo;
            }
            if (jumper.activeSelf )
            {
                hasJump = GameObject.Find("Jumper").GetComponent<jumpScript>().isActive;
            }
            if (jumper2.activeSelf)
            {
                hasJump2 = GameObject.Find("Jumper2").GetComponent<jumpScript>().isActive;
            }

            // Grab current position of player 
            speedPosition = transform.position;

            // If Turbo/Turbo2 has been triggered increase speed
            if (hasTurbo)
            {
                rb.AddForce(speedPosition * 100f);
            }
            if (hasTurbo2)
            {
                rb.AddForce(speedPosition * 100f);
            }

            // If Jump/Jump2 has been triggered move in the Y axis
            if (hasJump)
            {
                rb.AddForce(0, 400, 0);
            }
            if (hasJump2)
            {
                rb.AddForce(0, 400, 0);
            }
        }

        if (restartController == true)  //if r has been hit ie if game has been restarted.
        {
            winGame = false;
            checkReachedGoal = true;

        }
    }
}
