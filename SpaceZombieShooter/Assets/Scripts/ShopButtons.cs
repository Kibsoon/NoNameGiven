using UnityEngine;
using System.Collections;

public class ShopButtons : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}



	// Update is called once per frame
	void Update () {
	
		if(Input.GetMouseButtonDown(0))
		{
			if(gameObject.name == "PlayerHPUp")
				GameObject.Find ("Player").SendMessage("playerHPUp", SendMessageOptions.DontRequireReceiver);

			if(gameObject.name == "BaseHPUp")
				GameObject.Find ("SpaceBase").SendMessage("playerHPUp", SendMessageOptions.DontRequireReceiver);

			//if(gameObject.name == "AttackUp")
				//GameObject.Find ("Laser(Clone)").SendMessage("playerAttackUp", SendMessageOptions.DontRequireReceiver);



		}



	}






}
