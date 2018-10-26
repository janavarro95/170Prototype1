using Assets.Scripts.PlayerScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour {

    public static int numberOfPlayers;


    public int id;
    public PlayerController movement;
    public PlayerDisplayController appearance;


	// Use this for initialization
	void Start () {
        initializePlayer();
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void initializePlayer()
    {
        numberOfPlayers++;
        this.id = numberOfPlayers;
        this.gameObject.AddComponent<PlayerController>();
        this.movement = this.gameObject.GetComponent<PlayerController>();
        this.movement.player = this;

        this.gameObject.AddComponent<PlayerDisplayController>();
        this.appearance = this.gameObject.GetComponent<PlayerDisplayController>();
        this.appearance.player = this;
    }


}
