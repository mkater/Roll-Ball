using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour {

    static int currentScore = 0;

    public bool gamePlay;
    public bool restart;

    public GameObject ball; //making objects of ball and ramp
    public GameObject goal;
    public Text level;

    private Vector3 originalPosBall;
    private Scene scene;
    private float time = 7;


	void Start ()
    {
        scene = SceneManager.GetActiveScene();      //gets active scene
        originalPosBall = ball.transform.position;  //setting variable to hold the original position and rotation of the ball and ramp.
        Physics.autoSimulation = false; //ball doesn't use physics in build mode.  Will just stay in place while user sets up world

        level.text = scene.name;        //displays scene name
     
    }
	
	// Update is called once per frame
	void Update ()
    {
        scene = SceneManager.GetActiveScene();

        if (Input.GetKey(KeyCode.P))
        {
            Physics.autoSimulation = true; //ball uses physics now, game will start with ball falling.
            gamePlay = true; // set gamePlay flag to true when gameMode begins.
            restart = false;
            level.text = " ";

        }
        if(Input.GetKey(KeyCode.R))
        {
            gamePlay = false;   //gameplay is turned off
            ball.transform.position = originalPosBall;  //sending ball to original position
            Physics.autoSimulation = false;             //physics is now off.
            restart = true;     // restart is truned on
            goal.SetActive(true); //reactivate goal after restart
            level.text = scene.name;
        }

        if(time < 1)
        {
            level.text = "";
        }

        time -= time * Time.deltaTime;

        //Debug.Log("time: " + time);
    }

    public void Score()
    {
        currentScore++;
    }
    public int GetScore()
    {
        return currentScore;
    }
}
