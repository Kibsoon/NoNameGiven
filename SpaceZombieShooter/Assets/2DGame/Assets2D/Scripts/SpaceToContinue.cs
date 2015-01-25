using UnityEngine;
using System.Collections;

public class SpaceToContinue : MonoBehaviour {

	public string sceneName = "MainMenuScene";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown ("space") ) 
		{
			Application.LoadLevel(sceneName);
		}
	}
}
