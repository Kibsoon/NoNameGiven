using UnityEngine;
using System.Collections;

public class ShopButtons : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnMouseDown()
	{
		if(gameObject.name == "Cube1")
			GameObject.Find ("Shop").SendMessage("buyThingsFromPlayerButtons", "Cube1", SendMessageOptions.DontRequireReceiver);
		if(gameObject.name == "Cube2")
			GameObject.Find ("Shop").SendMessage("buyThingsFromPlayerButtons", "Cube2", SendMessageOptions.DontRequireReceiver);
		if(gameObject.name == "Cube3")
			GameObject.Find ("Shop").SendMessage("buyThingsFromPlayerButtons", "Cube3", SendMessageOptions.DontRequireReceiver);
		if(gameObject.name == "Cube4")
			GameObject.Find ("Shop").SendMessage("buyThingsFromPlayerButtons", "Cube4", SendMessageOptions.DontRequireReceiver);
		if(gameObject.name == "Cube5")
			GameObject.Find ("Shop").SendMessage("buyThingsFromPlayerButtons", "Cube5", SendMessageOptions.DontRequireReceiver);
		if(gameObject.name == "Cube6")
			GameObject.Find ("Shop").SendMessage("buyThingsFromPlayerButtons", "Cube6", SendMessageOptions.DontRequireReceiver);
		if(gameObject.name == "Cube7")
			GameObject.Find ("Shop").SendMessage("buyThingsFromPlayerButtons", "Cube7", SendMessageOptions.DontRequireReceiver);
	}

	// Update is called once per frame
	void Update () {
	



	}






}
