using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpScript : MonoBehaviour
{
    private string objectName;
    public GameObject player;
    public GameObject jumper;   //gameObject for the jumper
    public bool isActive;
    private float startTime = 10;

    private void Update()
    {
        // Check if jump has been triggered, should only be active for 10 frames
        if (isActive == true)
        {
            startTime -= 1;
            if (startTime < 0)
            {
                isActive = false;
                startTime = 10;
            }
        }
    }

    // Check if jump has been triggered
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            isActive = true;
        }
    }
}
