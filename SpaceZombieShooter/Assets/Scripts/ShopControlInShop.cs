using UnityEngine;
using System.Collections;

public class ShopControlInShop : MonoBehaviour {

	public GameObject turrets;
	public float money =0f;

	public float costHealPlayer = 100f;
	public float costHealBase = 200f;
	public float costMaxHPPlayer = 400f;
	public float costMaxHPBase = 600f;
	public float costNewTurets = 10000f;


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

		
	}
}
