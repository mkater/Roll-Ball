using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportingScript : MonoBehaviour {

    public GameObject teleportEntrance;
    public GameObject teleportEntrance2;
    public GameObject player;
    public GameObject teleportExit;
    public GameObject teleportExit2;
    private Vector3 exitTeleportLocation;
    private Vector3 exitTeleportLocation2;

    private void OnTriggerEnter(Collider other)
    {
        // Checks for entrance on teleport 1
        if (other.name == "Player" && teleportEntrance.CompareTag("Teleport"))
        {
            // Sets exit location for player at teleport exit
            exitTeleportLocation = teleportExit.transform.position;
            player.transform.position = exitTeleportLocation;
        }
        //checks for entrance on teleport 2
        else if (other.name == "Player" && teleportEntrance2.CompareTag("Teleport2"))
        {
            // Set exit location for player at teleport2 exit
            exitTeleportLocation2 = teleportExit2.transform.position;
            player.transform.position = exitTeleportLocation2;
        }
    }
}
