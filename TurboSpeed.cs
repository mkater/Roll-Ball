using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurboSpeed : MonoBehaviour
{

    public bool hasTurbo = false;
    private float startTime = 1;

    private void FixedUpdate()
    {
        // Check if Turbo has been triggered. Should only be active for 1 frame
        if (hasTurbo)
        {
            startTime -= 1;
            if (startTime < 0)
            {
                hasTurbo = false;
                startTime = 1;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            hasTurbo = true;
        }
    }
}
