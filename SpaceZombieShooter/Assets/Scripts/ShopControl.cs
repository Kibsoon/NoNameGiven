using UnityEngine;
using System.Collections;

public class ShopControl : MonoBehaviour {


	private GameObject player;
	private GameObject baseObject;
	private GameObject shop;
	private GameObject game2D;


	public GUIText toEnterShopGUI;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.Find("Player");
		baseObject = GameObject.FindWithTag ("Friend");
		shop = GameObject.FindWithTag ("Shop");

		//renderer.enabled = false;
		shop.SetActive (false);
	}


	bool IsProperlyDistance(float distance)
	{
		if (distance <= 50)
			return true;
		return false;
	}

	// Update is called once per frame
	void Update () {
	



		var playerDistance = Vector3.Distance(baseObject.transform.position, player.transform.position);
		
		
		if (IsProperlyDistance (playerDistance)  ) 
		{
			if(Screen.showCursor == false)
				toEnterShopGUI.text = "Naciśnij P żeby wejść do sklepu!";


				if(Input.GetKeyDown ("p"))
				{
					toEnterShopGUI.text = "Naciśnij O żeby wyjść ze sklepu!";
				
					player.SendMessageUpwards("stopEngines", SendMessageOptions.DontRequireReceiver);
					
					Screen.showCursor = true; 
					shop.SetActive (true);
				}



			if(Input.GetKeyDown ("o"))
			{
				toEnterShopGUI.text = "Naciśnij P żeby wejść do sklepu!";

				player.SendMessageUpwards("startEngines", SendMessageOptions.DontRequireReceiver);

				Screen.showCursor = false; 
				shop.SetActive (false);
			}
		}
		else toEnterShopGUI.text = " ";

		if(toEnterShopGUI.text == "Naciśnij O żeby wyjść ze sklepu!") 
			player.SendMessageUpwards("stopEngines", SendMessageOptions.DontRequireReceiver);


	}
}
