using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour {

    public Button startButton;

	// Use this for initialization
	void Start () {
        startButton.onClick.AddListener(ok);
    }
	
	// Update is called once per frame
	void Update () {
       
	}

    public void ok()
    {
        Debug.Log("Hello world");
    }

}
