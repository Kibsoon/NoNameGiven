using UnityEngine;
using System.Collections;

public class ShopControlInShop : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown ("e"))
		{
			GameObject.Find ("Player").SendMessage("playerHPUp", SendMessageOptions.DontRequireReceiver);
		}
		if(Input.GetKeyDown ("r"))
		{
			GameObject.Find ("SpaceBase").SendMessage("playerHPUp", SendMessageOptions.DontRequireReceiver);
		}
		if(Input.GetKeyDown ("t"))
		{
			GameObject.FindWithTag ("Enemy").SendMessage("moreDamageToEnemy", SendMessageOptions.DontRequireReceiver);
		}

		
	}
}
