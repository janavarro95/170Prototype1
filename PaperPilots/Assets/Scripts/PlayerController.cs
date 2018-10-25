using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float movementSpeed;
    public string key1;
    public string key2;

    void Update()
    {
        // Player Movement
        float moveX = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        transform.Translate(moveX, 0.0f, moveZ);
    }

    public bool pullUp() // Function that returns whether the player is "pulling up"
    {
        if (Input.GetKey(key1))
            return true;
        else
            return false;
    }

    public bool pushDown() // Function that returns whether the player is "pushing down"
    {
        if (Input.GetKey(key2))
            return true;
        else
            return false;
    }
}

