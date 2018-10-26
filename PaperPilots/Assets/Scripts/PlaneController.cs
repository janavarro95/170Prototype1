using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour {

    public float speed;
    public GameObject player;
    public GameObject[] zone;

    private FlightAdjustmentZoneController currentZone;
    private Vector3 shiftAmount;
    private Vector3 rotationAmount;

	// Use this for initialization
	void Start () {
        print("Plane Initialized");
        shiftAmount = new Vector3 (0f, 0f, speed * Time.deltaTime);
	}
	
	// Update is called once per frame
	void Update () {
        // Move plane and player
        transform.Translate(shiftAmount);
        //player.transform.Translate(shiftAmount);

        updateRotationAmount();

        //print(rotationAmount);

        transform.Rotate(rotationAmount);

    
	}

    void updateRotationAmount()
    {
        // Adjust rotation amount
        //print("ok");
        rotationAmount.Set(0, 0, 0);
        for (int i = 0; i < zone.Length; i++) // add the vectors for each zone
        {
            currentZone = zone[i].GetComponent<FlightAdjustmentZoneController>();
            rotationAmount += currentZone.getVector();
        }
  
        
    }
}
