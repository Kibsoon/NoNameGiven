using UnityEngine;
using System.Collections;

public class ShopControl : MonoBehaviour {


	private GameObject player;
	private GameObject baseObject;
	private GameObject shop;

	public GUIText toEnterShopGUI;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindWithTag("Player");
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
		
		
		if (IsProperlyDistance (playerDistance)) 
		{
			toEnterShopGUI.text = "Naciśnij P żeby wejść do sklepu!";

			//if(toEnterShopGUI.text == "Naciśnij F żeby wejść do sklepu!" )
			//{
				//toEnterShopGUI.text = "Naciśnij F żeby wejść do sklepu!";

				if(Input.GetKeyDown ("p"))
				{
					player.SendMessageUpwards("stopEngines", SendMessageOptions.DontRequireReceiver);
					
					Screen.showCursor = true; 
					shop.SetActive (true);
				}
			//}


			if(Input.GetKeyDown ("o"))
			{
				player.SendMessageUpwards("startEngines", SendMessageOptions.DontRequireReceiver);

				Screen.showCursor = false; 
				shop.SetActive (false);
			}
		}
		else toEnterShopGUI.text = " ";



	}
}
