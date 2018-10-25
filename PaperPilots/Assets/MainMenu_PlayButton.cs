using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_PlayButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// TODO: Make this go to a player join/selection screen instead.
    /// 
    /// Functionality for when the main menu play button is clicked.
    /// </summary>
    public void onButtonClick()
    {
       
        SceneManager.LoadScene("Gameplay");
    }
}
