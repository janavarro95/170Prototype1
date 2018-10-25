using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightAdjustmentZoneController : MonoBehaviour {

    public bool switchAxis;
    public float tiltDegree;

    private bool active;

    private PlayerController playerController; // Needed to get player actions from player script

    void OnTriggerStay(Collider other)
    {
        playerController = other.gameObject.GetComponent<PlayerController>(); // get player script from the collider
        if (playerController != null) // if player controller is null, then collider is not a player
        {
            if (playerController.pullUp())
            {
               // print("9");
                active = true;
            }
            else if (playerController.pushDown())
                active = true;
            else
                active = false;
        }
    }

    public Vector3 getVector()
    {
        if (active)
        {
            if (switchAxis)
                return new Vector3(0, 0, tiltDegree);
            else
                return new Vector3(tiltDegree, 0, 0);
        }
        else
            return new Vector3(0, 0, 0);
    }
}
