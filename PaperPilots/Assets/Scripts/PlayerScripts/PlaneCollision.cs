using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

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

        Destroy(collision.transform.gameObject); //Destroy the other object we run into.
    }
}
