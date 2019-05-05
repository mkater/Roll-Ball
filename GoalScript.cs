using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour {

    public GameObject goal;

    public bool winner = false;

    public static bool w1 = false;
    public static bool w2 = false;
    public static bool w3 = false;

    private Scene scene;
    private void Update()
    {
        // Check if 'R' has been clicked
        if(Input.GetKey(KeyCode.R))
        {
            winner = false;
        }
    }
    private void OnTriggerEnter()
    {
        scene = SceneManager.GetActiveScene();
        // Goal has been triggered
        if (goal.CompareTag("Goal"))
        {
            winner = true;

            GameObject.Find("GameController").GetComponent<GameControllerScript>().Score();
        }
        if(scene.name == "World 1")
        {
            w1 = true;
            Debug.Log(w1);
        }
        else if(scene.name == "World 2")
        {
            w2 = true;
        }
        else if (scene.name == "World 3")
        {
            w3 = true;
        }
    }
}
