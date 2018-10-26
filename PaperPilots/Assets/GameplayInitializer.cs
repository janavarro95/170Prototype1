using Assets.Scripts.PlayerScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayInitializer : MonoBehaviour {

	// Use this for initialization
	void Start () {

        Debug.Log("Hello!");

        if (PlayerList.player1 != null)
        {
            PlayerList.player1.transform.position = new Vector3(-3, 0, 0);
        }
        if (PlayerList.player2 != null)
        {
            PlayerList.player2.transform.position = new Vector3(3, 0, 0);
        }
        if (PlayerList.player3 != null)
        {
            PlayerList.player3.transform.position = new Vector3(0, 3, 0);
        }
        if (PlayerList.player4 != null)
        {
            PlayerList.player4.transform.position = new Vector3(0, -3, 0);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
