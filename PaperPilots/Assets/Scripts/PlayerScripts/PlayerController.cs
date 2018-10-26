using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public PlayerHandler player;

    public float movementSpeed;
    public string key1;
    public string key2;


    private void Start()
    {
        this.movementSpeed = 10f;
    }

    void Update()
    {
        Debug.Log(SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name == "CharacterSelectionMenu") return; //Ignore Movement updates on Player if in menu.
        // Player Movement
        float moveX = Input.GetAxis("P" + player.id.ToString()+ " Horizontal") * movementSpeed * Time.deltaTime;
        float moveZ = Input.GetAxis("P"+player.id.ToString()+" Vertical") * movementSpeed * Time.deltaTime;
        player.gameObject.transform.Translate(moveX, 0.0f, moveZ);
    }

    public bool pullUp() // Function that returns whether the player is "pulling up"
    {
        if (Input.GetButton(getPlayerID() + " Select"))
        {
            return true;
        }
        else return false;

        /*
        if (Input.GetKey(key1))
            return true;
        else
            return false;
            */
    }

    public bool pushDown() // Function that returns whether the player is "pushing down"
    {
        if (Input.GetButton(getPlayerID() + " Deselect"))
        {
            return true;
        }
        else return false;
        /*
        if (Input.GetKey(key2))
            return true;
        else
            return false;
        */
    }

    public string getPlayerID()
    {
        return "P" + this.player.id.ToString();
    }
}

