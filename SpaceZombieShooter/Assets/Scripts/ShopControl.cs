using UnityEngine;
using System.Collections;

public class ShopControl : MonoBehaviour {


	private GameObject player;
	private GameObject baseObject;
	private GameObject shop;
	private GameObject game2D;
	private GameObject buttons;




	public GUIText toEnterShopGUI;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.Find("Player");
		baseObject = GameObject.FindWithTag ("Friend");
		shop = GameObject.FindWithTag ("Shop");

		//renderer.enabled = false;
		shop.SetActive (false);

		buttons = GameObject.Find ("ShopButtons");
		buttons.SetActive (false);

	}


	bool IsProperlyDistance(float distance)
	{
		if (distance <= 50)
			return true;
		return false;
	}

	// Update is called once per frame
	void Update () {
	
		Screen.lockCursor = false;
		if(!player)
			return;


		var playerDistance = Vector3.Distance(baseObject.transform.position, player.transform.position);
		
		
		if (IsProperlyDistance (playerDistance)  ) 
		{
			if(Screen.showCursor == false)
				toEnterShopGUI.text = "Press E to open shop!";


				if(Input.GetKeyDown ("e"))
				{
					toEnterShopGUI.text = "Press Q to close shop";
				
					player.SendMessageUpwards("stopEngines", SendMessageOptions.DontRequireReceiver);
					
				//player.transform.rotation.Set(0f,0f,0f,0f);
					


					Screen.showCursor = true; 
					shop.SetActive (true);
					buttons.SetActive (true);
				}



			if(Input.GetKeyDown ("q"))
			{
				toEnterShopGUI.text = "Press E to open shop!";

				player.SendMessageUpwards("startEngines", SendMessageOptions.DontRequireReceiver);

				Screen.showCursor = false; 
				shop.SetActive (false);
				buttons.SetActive (false);
			}
		}
		else toEnterShopGUI.text = " ";

		if(toEnterShopGUI.text == "Press Q to close shop") 
			player.SendMessageUpwards("stopEngines", SendMessageOptions.DontRequireReceiver);


	}
}
