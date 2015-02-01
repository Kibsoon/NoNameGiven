using UnityEngine;
using System.Collections;

public class SpaceToContinue : MonoBehaviour {

	public string sceneName = "MainMenuScene";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		Screen.showCursor = true; 

		if (Input.GetKeyDown ("space") || Input.GetKeyDown(KeyCode.Mouse0)) 
		{
			Screen.showCursor = false; 
			Application.LoadLevel(sceneName);
		}
	}
}
