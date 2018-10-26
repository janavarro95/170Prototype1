using Assets.Scripts.PlayerScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelection : MonoBehaviour {

    public int numberOfLoggedPlayers;

    public GameObject playerBase;


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

        checkForAllPlayersIn();
    }

    public void checkForPlayerInstantiate()
    {
        if (Input.GetButton(getPlayerID(1) + " Select") && PlayerList.player1 == null)
        {
            PlayerList.player1 = Instantiate(playerBase);
            PlayerList.player1.transform.position = new Vector3(-7, PlayerList.player1.transform.position.y, PlayerList.player1.transform.position.z);
            DontDestroyOnLoad(PlayerList.player1);
        }
        if (Input.GetButton(getPlayerID(2) + " Select") && PlayerList.player2 == null)
        {
            PlayerList.player2 = Instantiate(playerBase);
            PlayerList.player2.transform.position = new Vector3(-2, PlayerList.player1.transform.position.y, PlayerList.player1.transform.position.z);
            DontDestroyOnLoad(PlayerList.player2);
        }
        if (Input.GetButton(getPlayerID(3) + " Select") && PlayerList.player3 == null)
        {
            PlayerList.player3 = Instantiate(playerBase);
            PlayerList.player3.transform.position = new Vector3(3, PlayerList.player1.transform.position.y, PlayerList.player1.transform.position.z);
            DontDestroyOnLoad(PlayerList.player3);
        }
        if (Input.GetButton(getPlayerID(4) + " Select") && PlayerList.player4 == null)
        {
            PlayerList.player4 = Instantiate(playerBase);
            PlayerList.player4.transform.position = new Vector3(8, PlayerList.player1.transform.position.y, PlayerList.player1.transform.position.z);
            DontDestroyOnLoad(PlayerList.player4);
        }
    }

    public void checkForPlayerColorChange()
    {
        if (PlayerList.player1 != null)
        {
            if (player1ColorChange == false)
            {
                if (Input.GetAxis(getPlayerID(1) + " Horizontal") < 0)
                {
                    player1ColorChange = true;
                    PlayerList.player1.GetComponent<PlayerHandler>().appearance.decrementColor();
                }
                else if (Input.GetAxis(getPlayerID(1) + " Horizontal") > 0)
                {
                    player1ColorChange = true;
                    PlayerList.player1.GetComponent<PlayerHandler>().appearance.incrementColor();
                }
            }

            if (Input.GetAxis(getPlayerID(1) + " Horizontal") == 0)
            {
                player1ColorChange = false;
            }
        }
        if (PlayerList.player2 != null)
        {
            if (player2ColorChange == false)
            {

                if (Input.GetAxis(getPlayerID(2) + " Horizontal") < 0)
                {
                    player2ColorChange = true;
                    PlayerList.player2.GetComponent<PlayerHandler>().appearance.decrementColor();
                }
                else if (Input.GetAxis(getPlayerID(2) + " Horizontal") > 0)
                {
                    player2ColorChange = true;
                    PlayerList.player2.GetComponent<PlayerHandler>().appearance.incrementColor();
                }
            }

            if (Input.GetAxis(getPlayerID(2) + " Horizontal") == 0)
            {
                player2ColorChange = false;
            }

        }
        if (PlayerList.player3 != null)
        {
            if (player3ColorChange == false)
            {

                if (Input.GetAxis(getPlayerID(3) + " Horizontal") < 0)
                {
                    player3ColorChange = true;
                    PlayerList.player3.GetComponent<PlayerHandler>().appearance.decrementColor();
                }
                else if (Input.GetAxis(getPlayerID(3) + " Horizontal") > 0)
                {
                    player3ColorChange = true;
                    PlayerList.player3.GetComponent<PlayerHandler>().appearance.incrementColor();
                }
            }
            if (Input.GetAxis(getPlayerID(3) + " Horizontal") == 0)
            {
                player3ColorChange = false;
            }
        }
        if (PlayerList.player4 != null)
        {
            if (player4ColorChange == false)
            {
                if (Input.GetAxis(getPlayerID(4) + " Horizontal") < 0)
                {
                    player4ColorChange = true;
                    PlayerList.player4.GetComponent<PlayerHandler>().appearance.decrementColor();
                }
                else if (Input.GetAxis(getPlayerID(4) + " Horizontal") > 0)
                {
                    player4ColorChange = true;
                    PlayerList.player4.GetComponent<PlayerHandler>().appearance.incrementColor();
                }
            }
            if (Input.GetAxis(getPlayerID(4) + " Horizontal") == 0)
            {
                player4ColorChange = false;
            }

        }
    }

    public void checkForAllPlayersIn()
    {
        if(Input.GetButton(getPlayerID(1)+" Start"))
        {
            SceneManager.LoadScene("Gameplay");
        }
    }

    public string getPlayerID(int index)
    {
        return "P" + index.ToString();
    }
}
