using UnityEngine;
using System.Collections;

public class ShopControlInShop : MonoBehaviour {

	public GameObject turrets;
	public GameObject turretsHeavy;
	public GameObject turretsSlowing;

	public float money =0f;

	public float costHealPlayer = 100f;
	public float costHealBase = 200f;
	public float costMaxHPPlayer = 400f;
	public float costMaxHPBase = 600f;
	public float costNewTurets = 10000f;
	public float costNewHeavyTurets = 15000f;
	public float costNewSlowingTurets = 10000f;


	// Use this for initialization
	void Start () {
	
	}

	void setMoney(float newMoney)
	{
		money = newMoney;
	}



	// Update is called once per frame
	void Update () {

		//setMoney ();

	
		if(Input.GetKeyDown ("x") && money >= costHealPlayer)
		{
			GameObject.Find ("Player").SendMessage("playerHPUp", SendMessageOptions.DontRequireReceiver);
			money -= costHealPlayer;
			GameObject.Find ("GameObjectForScripts").SendMessageUpwards ("setMoney", money, SendMessageOptions.DontRequireReceiver);
		}
		if(Input.GetKeyDown ("v") && money >= costHealBase)
		{
			GameObject.Find ("SpaceBase").SendMessage("playerHPUp", SendMessageOptions.DontRequireReceiver);
			money -= costHealBase;
			GameObject.Find ("GameObjectForScripts").SendMessageUpwards ("setMoney", money, SendMessageOptions.DontRequireReceiver);

		}

		if(Input.GetKeyDown ("z") && money >= costMaxHPPlayer)
		{
			GameObject.Find ("Player").SendMessage("playerHPMaxUp", SendMessageOptions.DontRequireReceiver);
			money -= costMaxHPPlayer;
			GameObject.Find ("GameObjectForScripts").SendMessageUpwards ("setMoney", money, SendMessageOptions.DontRequireReceiver);

		}
		if(Input.GetKeyDown ("c") && money >= costMaxHPBase)
		{
			GameObject.Find ("SpaceBase").SendMessage("playerHPMaxUp", SendMessageOptions.DontRequireReceiver);
			money -= costMaxHPBase;
			GameObject.Find ("GameObjectForScripts").SendMessageUpwards ("setMoney", money, SendMessageOptions.DontRequireReceiver);

		}


		if(Input.GetKeyDown ("b") && money >= costNewTurets)
		{
			GameObject.Instantiate(turrets);
			money -= costNewTurets;
			GameObject.Find ("GameObjectForScripts").SendMessageUpwards ("setMoney", money, SendMessageOptions.DontRequireReceiver);

		}

		if(Input.GetKeyDown ("n") && money >= costNewHeavyTurets)
		{
			GameObject.Instantiate(turretsHeavy);
			money -= costNewHeavyTurets;
			GameObject.Find ("GameObjectForScripts").SendMessageUpwards ("setMoney", money, SendMessageOptions.DontRequireReceiver);
			
		}

		if(Input.GetKeyDown ("m") && money >= costNewSlowingTurets)
		{
			GameObject.Instantiate(turretsSlowing);
			money -= costNewSlowingTurets;
			GameObject.Find ("GameObjectForScripts").SendMessageUpwards ("setMoney", money, SendMessageOptions.DontRequireReceiver);
			
		}
		
	}









	// shoping by mouse 
	void buyThingsFromPlayerButtons(string cubeNr)
	{
		//Debug.Log ("jest git" + cubeNr);


		if(cubeNr == "Cube2" && money >= costHealPlayer)
		{
			GameObject.Find ("Player").SendMessage("playerHPUp", SendMessageOptions.DontRequireReceiver);
			money -= costHealPlayer;
			GameObject.Find ("GameObjectForScripts").SendMessageUpwards ("setMoney", money, SendMessageOptions.DontRequireReceiver);
		}
		if(cubeNr == "Cube4" && money >= costHealBase)
		{
			GameObject.Find ("SpaceBase").SendMessage("playerHPUp", SendMessageOptions.DontRequireReceiver);
			money -= costHealBase;
			GameObject.Find ("GameObjectForScripts").SendMessageUpwards ("setMoney", money, SendMessageOptions.DontRequireReceiver);
			
		}
		
		if(cubeNr == "Cube1" && money >= costMaxHPPlayer)
		{
			GameObject.Find ("Player").SendMessage("playerHPMaxUp", SendMessageOptions.DontRequireReceiver);
			money -= costMaxHPPlayer;
			GameObject.Find ("GameObjectForScripts").SendMessageUpwards ("setMoney", money, SendMessageOptions.DontRequireReceiver);
			
		}
		if(cubeNr == "Cube3" && money >= costMaxHPBase)
		{
			GameObject.Find ("SpaceBase").SendMessage("playerHPMaxUp", SendMessageOptions.DontRequireReceiver);
			money -= costMaxHPBase;
			GameObject.Find ("GameObjectForScripts").SendMessageUpwards ("setMoney", money, SendMessageOptions.DontRequireReceiver);
			
		}
		
		
		if(cubeNr == "Cube5" && money >= costNewTurets)
		{
			GameObject.Instantiate(turrets);
			money -= costNewTurets;
			GameObject.Find ("GameObjectForScripts").SendMessageUpwards ("setMoney", money, SendMessageOptions.DontRequireReceiver);
			
		}

		if(cubeNr == "Cube6" && money >= costNewHeavyTurets)
		{
			GameObject.Instantiate(turretsHeavy);
			money -= costNewHeavyTurets;
			GameObject.Find ("GameObjectForScripts").SendMessageUpwards ("setMoney", money, SendMessageOptions.DontRequireReceiver);
			
		}

		if(cubeNr == "Cube7" && money >= costNewSlowingTurets)
		{
			GameObject.Instantiate(turretsSlowing);
			money -= costNewSlowingTurets;
			GameObject.Find ("GameObjectForScripts").SendMessageUpwards ("setMoney", money, SendMessageOptions.DontRequireReceiver);
			
		}


	}


}



