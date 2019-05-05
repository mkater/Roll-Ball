using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    Scene scene;
    private int a = 0;
    private int b = 0;
    private int c = 0;
    private int d = 0;
    private int e = 0;
    private int f = 0;
    private int score;
    private int coutner = 1;
    private bool is_Instructions;
    private bool gameWon;

    public GameObject ramp;
    public GameObject plane;
    public GameObject s_shape;
    public GameObject teleporter_in;
    public GameObject teleporter_out;
    public GameObject turbo;
    public GameObject jumper;
    public GameObject ramp2;
    public GameObject plane2;
    public GameObject s_shape2;
    public GameObject teleporter_in2;
    public GameObject teleporter_out2;
    public GameObject turbo2;
    public GameObject jumper2;
    public Text instructions;
    public Text levelDisplay;
    public Font font;


    private GUIStyle style = new GUIStyle();
    private GUIStyle levelStyle = new GUIStyle();
    private GUIStyle instructionStyle = new GUIStyle();

    private Rect optionRect = new Rect(20, 20, 260, 210);   //formatting for the displays
    private Rect instructionRect = new Rect(20, 240, 260, 60);
    private Rect levelRect = new Rect(Screen.width / 2, Screen.height / 4, 260, 100);
    private Rect chooseLevelRect = new Rect(20, 320, 360, 100);
    private Rect worldRect = new Rect(20, 460, 360, 150);

    private int maxObjects = 12;        //setting max number of objects in scene to 12
    private int usedObjects = 0;        // NEW LINE
    private bool allow = true;
    private bool haveShape2 = true;
    private bool haveShape3 = true;

    private void OnGUI()
    {
        style.fontSize = 25;            //more formatting for text that appears.
        style.font = font;
        style.normal.textColor = Color.white;
        style.alignment = TextAnchor.MiddleCenter;

        levelStyle.fontSize = 70;       //more formatting
        levelStyle.font = font;
        levelStyle.normal.textColor = Color.white;
        levelStyle.alignment = TextAnchor.MiddleCenter;
        levelStyle.alignment = TextAnchor.MiddleCenter;

        instructionStyle.fontSize = 50;       //more formatting
        instructionStyle.font = font;
        instructionStyle.normal.textColor = Color.white;
        instructionStyle.alignment = TextAnchor.MiddleCenter;
        instructionStyle.alignment = TextAnchor.MiddleCenter;

        optionRect = GUILayout.Window(0, optionRect, DoMyWindow, "OBJECTS");

        instructionRect = GUILayout.Window(1, instructionRect, DoMyInstructionWindow, "INFO");

        chooseLevelRect = GUILayout.Window(3, chooseLevelRect, DoMyChooseLevelWindow, "STATS");

        worldRect = GUILayout.Window(4, worldRect, DoMyWorldWindow, "WORLDS");

        if (gameWon)            //after winning, this will display
        {
            levelRect = GUILayout.Window(2, levelRect, DoMyLevelWindow, " WOULD YOU LIKE TO CONTINUE?");
        }

        GUI.Box(new Rect(50, 50, Screen.width, Screen.height), levelDisplay.text, levelStyle); // Display level and number

        if (is_Instructions)
        {
            GUI.Box(new Rect(Screen.width / 3, Screen.height / 7, 900, 600), instructions.text, instructionStyle);
        }
    }

    private void Update()
    {
        levelDisplay = GameObject.Find("GameController").GetComponent<GameControllerScript>().level;        //checks game status

        gameWon = GameObject.Find("Player").GetComponent<PlayerScript>().winGame;

        score = GameObject.Find("GameController").GetComponent<GameControllerScript>().GetScore();
    }

    public void DoMyWindow(int windowID0)
    {
        scene = SceneManager.GetActiveScene();      //setting the maximum number of objects on each world.

        if (scene.name == "World 2")
        {
            maxObjects = 8;
        }
        if (scene.name == "World 3")
        {
            maxObjects = 6;
        }
     
        if (a + b + c + d + e + f >= maxObjects)        //no more objects if the combined total is greater than maxObjects
        {
            allow = false;
        }
        // Place Objects in screen depending on the button clicked
        if (GUILayout.Button("RAMP", style))        //spawning all of the different objects
        {
            if (allow)
            {
                if (a == 0)
                {
                    a = createObjects(ramp, a, true);
                }
                else if (a == 1 && scene.name != "World 1")
                {
                    a = createObjects(ramp2, a, true);
                }
            }
        }

        if (GUILayout.Button("PLANE", style))
        {
            if (allow && haveShape3)
            {
                if (b == 0)
                {
                    b = createObjects(plane, b, true);
                }
                else if (b == 1)
                {
                    b = createObjects(plane2, b, true);
                }
            }
        }

        if (GUILayout.Button("S-SHAPE", style))
        {
            if (allow && haveShape2)
            {
                if (c == 0)
                {
                    c = createObjects(s_shape, c, true);
                }
                else if (c == 1)
                {
                    c = createObjects(s_shape2, c, true);
                }
            }

        }
        if (GUILayout.Button("JUMPER", style))
        {
            if (allow && haveShape3)
            {
                if (d == 0)
                {
                    d = createObjects(jumper, d, true);
                }
                else if (d == 1)
                {
                    d = createObjects(jumper2, d, true);
                }
            }
        }
        if (GUILayout.Button("TURBO", style))
        {
            if (allow)
            {
                if (e == 0)
                {
                    e = createObjects(turbo, e, true);
                }
                else if (e == 1)
                {
                    e = createObjects(turbo2, e, true);
                }
            }
        }
        if (GUILayout.Button("TELEPORTER", style))
        {
            if (allow && haveShape2)
            {
                if (f == 0)
                {
                    f = createObjects(teleporter_in, f, false);
                    f = createObjects(teleporter_out, f, true);
                }
                else if (f == 1)
                {
                    f = createObjects(teleporter_in2, f, false);
                    f = createObjects(teleporter_out2, f, true);
                }
            }
        }
    }

    public int createObjects(GameObject name, int count, bool updateCount)
    {

        name.SetActive(true);       //setting the objects to active
        if (updateCount)
        {
            count++;
            usedObjects++;        // NEW LINE
        }
        return count;
    }

    public void DoMyInstructionWindow(int windowID1)        //instructions window.  not completed due in future iteration.
    {
        if (GUILayout.Button("INSTRUCTIONS", style))
        {
            if (coutner % 2 != 0)
            {
                Debug.Log("here");
                instructions.text = "Press 4, 5, 6 to rotate objects.\n" +
                    "Press X, Y, Z to move them.\n" +
                    "Press 'P' to start, 'R' to reset \nto original position\n" +
                    "and 'P' to play again";
            }
            else
            {
                instructions.text = "";
            }
            coutner++;
            is_Instructions = true;
            Debug.Log(is_Instructions + "is_instruction");
        }
    }

    public void DoMyLevelWindow(int windowID2)      //display that shows up after beating a level
    {
        scene = SceneManager.GetActiveScene();

        if (GUILayout.Button("YES", style))
        {
            if (scene.name == "World 1")
            {
                SceneManager.LoadScene("World 2");
            }
            else if (scene.name == "World 2")
            {
                SceneManager.LoadScene("World 3");
            }
        }
        else if (GUILayout.Button("RESTART LEVEL", style))
        {
            SceneManager.LoadScene(scene.name);
        }
    }

    public void DoMyChooseLevelWindow(int windowID3)
    {
        scene = SceneManager.GetActiveScene();

        GUILayout.Box("CURRENT LEVEL : " + scene.name, style);

        GUILayout.Box("SCORE : " + score.ToString(), style);

        GUILayout.Box("OBJECTS AVAILABLE : " + (maxObjects - usedObjects), style); // NEW LINE
    }

    public void DoMyWorldWindow(int windowID4)
    {
        GUILayout.Box("CHOOSE LEVEL : ", style);

        if (GUILayout.Button("WORLD 1", style))
        {
            SceneManager.LoadScene("World 1");
        }

        if (GUILayout.Button("WORLD 2", style))
        {
            if (GoalScript.w1)
            {
                SceneManager.LoadScene("World 2");
            }
        }

        if (GUILayout.Button("WORLD 3", style))
        {
            if (GoalScript.w1 && GoalScript.w2)
            {
                SceneManager.LoadScene("World 3");
            }
        }
    }
}
