using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Tutorial Reference: https://www.youtube.com/watch?v=DmhSWEJjphQ


/// <summary>
/// Deals with a day/night cycle for unity.
/// </summary>
public class Sun : MonoBehaviour {

    Vector3 startPosition;
    public Light light;
    public float dayNightSpeed=10;

	// Use this for initialization
	void Start () {
        this.light = GetComponent<Light>();
        this.startPosition = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        
        if (this.transform.position.y < 0&& this.gameObject.name=="Sun")
        {
            RenderSettings.ambientIntensity = 0;
        }
        else
        {
            RenderSettings.ambientIntensity = 0.5f;
        }
        
        if (this.gameObject.name == "Sun")
        {
            this.light.intensity = gameObject.transform.position.y / startPosition.y;
            this.light.intensity *= 0.8f;
            
        }
        else if (this.gameObject.name == "Moon")
        {
            this.light.intensity = gameObject.transform.position.y / -startPosition.y;
            this.light.intensity *= 0.5f;
            
        }
        else
        {
            throw new System.Exception("Object is neither sun nor moon. What are we working with???");
        }
        

        transform.RotateAround(Vector3.zero, Vector3.right, dayNightSpeed * Time.deltaTime);
        transform.LookAt(Vector3.zero);
	}
}
