using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Health : MonoBehaviour {

	public float hitPoints = 10f;
	public float currentHitPoints;
	public GameObject destroyFX;



	// Use this for initialization
	void Start () 
	{
		currentHitPoints = hitPoints;


	}


	public void TakeDamage (float amt)
	{
		currentHitPoints -= amt;

		if(currentHitPoints <= 0)
		{
			currentHitPoints = 0;
			Die();
		}
	}

	void Die()
	{

        if (gameObject.tag == "Enemy" || gameObject.tag == "Friend" || gameObject.tag == "Player")
		{
			Instantiate(destroyFX, this.transform.position, this.transform.rotation);
			Destroy (gameObject);

			if(gameObject.tag == "Friend" || gameObject.tag == "Player")
			{
				Application.LoadLevel("GameOver");
			}

			if(gameObject.tag == "Enemy")
			{
				GameObject.Find ("GameObjectForScripts").SendMessage("addPoints", gameObject.name, SendMessageOptions.DontRequireReceiver);
			}


		}

	}


	float getCurrentHitPoints ()
	{
		return currentHitPoints;
	}


	void playerHPUp()
	{
		hitPoints += hitPoints * 0.1f;
		currentHitPoints = hitPoints;
	}


}
