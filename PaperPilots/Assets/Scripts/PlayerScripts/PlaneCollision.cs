using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCollision : MonoBehaviour {

    //REMEMBER THAT THE PLANE MUST HAVE A RIGID BODY!!!



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        //Can also use collision.transform.gameobject.name=="Something";

        Debug.Log(collision.other.name);

        if (collision.transform.gameObject.tag == "Player")
        {
            return;
        }

        if (collision.transform.gameObject.tag == "Coin")
        {
            //Increase player score.
        }

        if (collision.transform.gameObject.tag == "Boulder")
        {
            //Damage plane.
        }

        if (collision.transform.gameObject.tag == "Bee")
        {
            //???
        }

        if (collision.transform.gameObject.tag == "LoopBus")
        {
            //Remember to say thank you!
        }

        if (collision.transform.gameObject.tag == "Obstacle")
        {
            //Remember to say thank you!
            Debug.Log("Do some obstacle work!");
        }

        Destroy(collision.transform.gameObject); //Destroy the other object we run into.
    }
}
