using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelection : MonoBehaviour {

    public int numberOfLoggedPlayers;

    public GameObject playerBase;

    public static GameObject player1;
    public static GameObject player2;
    public static GameObject player3;
    public static GameObject player4;


    public bool player1ColorChange;
    public bool player2ColorChange;
    public bool player3ColorChange;
    public bool player4ColorChange;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        checkForPlayerInstantiate();
        checkForPlayerColorChange();
    }

    public void checkForPlayerInstantiate()
    {
        if (Input.GetButton(getPlayerID(1) + " Select") && player1 == null)
        {
            player1 = Instantiate(playerBase);
            player1.transform.position = new Vector3(-7, player1.transform.position.y, player1.transform.position.z);
        }
        if (Input.GetButton(getPlayerID(2) + " Select") && player2 == null)
        {
            player2 = Instantiate(playerBase);
            player2.transform.position = new Vector3(-2, player1.transform.position.y, player1.transform.position.z);

        }
        if (Input.GetButton(getPlayerID(3) + " Select") && player3 == null)
        {
            player3 = Instantiate(playerBase);
            player3.transform.position = new Vector3(3, player1.transform.position.y, player1.transform.position.z);
        }
        if (Input.GetButton(getPlayerID(4) + " Select") && player4 == null)
        {
            player4 = Instantiate(playerBase);
            player4.transform.position = new Vector3(8, player1.transform.position.y, player1.transform.position.z);
        }
    }

    public void checkForPlayerColorChange()
    {
        if (player1 != null)
        {
            if (player1ColorChange == false)
            {
                if (Input.GetAxis(getPlayerID(1) + " Horizontal") < 0)
                {
                    player1ColorChange = true;
                    player1.GetComponent<PlayerHandler>().appearance.decrementColor();
                }
                else if (Input.GetAxis(getPlayerID(1) + " Horizontal") > 0)
                {
                    player1ColorChange = true;
                    player1.GetComponent<PlayerHandler>().appearance.incrementColor();
                }
            }

            if (Input.GetAxis(getPlayerID(1) + " Horizontal") == 0)
            {
                player1ColorChange = false;
            }
        }
        if (player2 != null)
        {
            if (player2ColorChange == false)
            {

                if (Input.GetAxis(getPlayerID(2) + " Horizontal") < 0)
                {
                    player2ColorChange = true;
                    player2.GetComponent<PlayerHandler>().appearance.decrementColor();
                }
                else if (Input.GetAxis(getPlayerID(2) + " Horizontal") > 0)
                {
                    player2ColorChange = true;
                    player2.GetComponent<PlayerHandler>().appearance.incrementColor();
                }
            }

            if (Input.GetAxis(getPlayerID(2) + " Horizontal") == 0)
            {
                player2ColorChange = false;
            }

        }
        if (player3 != null)
        {
            if (player3ColorChange == false)
            {

                if (Input.GetAxis(getPlayerID(3) + " Horizontal") < 0)
                {
                    player3ColorChange = true;
                    player3.GetComponent<PlayerHandler>().appearance.decrementColor();
                }
                else if (Input.GetAxis(getPlayerID(3) + " Horizontal") > 0)
                {
                    player3ColorChange = true;
                    player3.GetComponent<PlayerHandler>().appearance.incrementColor();
                }
            }
            if (Input.GetAxis(getPlayerID(3) + " Horizontal") == 0)
            {
                player3ColorChange = false;
            }
        }
        if (player4 != null)
        {
            if (player4ColorChange == false)
            {
                if (Input.GetAxis(getPlayerID(4) + " Horizontal") < 0)
                {
                    player4ColorChange = true;
                    player4.GetComponent<PlayerHandler>().appearance.decrementColor();
                }
                else if (Input.GetAxis(getPlayerID(4) + " Horizontal") > 0)
                {
                    player4ColorChange = true;
                    player4.GetComponent<PlayerHandler>().appearance.incrementColor();
                }
            }
            if (Input.GetAxis(getPlayerID(4) + " Horizontal") == 0)
            {
                player4ColorChange = false;
            }

        }
    }

    public string getPlayerID(int index)
    {
        return "P" + index.ToString();
    }
}
