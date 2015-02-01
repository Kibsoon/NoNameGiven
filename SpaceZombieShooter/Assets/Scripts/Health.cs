using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Health : MonoBehaviour {

	public float hitPoints = 10f;
	public float currentHitPoints;
	public GameObject destroyFX;
    public GameObject explosion;
	private float damageToEnemy = 25f;

	public GUIText youLoseGUI;



	// Use this for initialization
	void Start () 
	{
		currentHitPoints = hitPoints;


	}


	public void TakeDamage (float amt)
	{
		//if(gameObject.tag == "Enemy")
		//	currentHitPoints -= damageToEnemy;
		//else
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
            //Instantiate(explosion, this.transform.position, this.transform.rotation);
			Destroy (gameObject);

			if(gameObject.tag == "Friend" || gameObject.tag == "Player")
			{
				if(gameObject.tag == "Friend")
					GameObject.Find("Player").SendMessageUpwards("TakeDamage", 999999, SendMessageOptions.DontRequireReceiver);

				youLoseGUI.text = "You Lose!!!";
				//if(Input.GetKeyDown ("q") && youLoseGUI.text == "You Lose!!!")

				//Application.LoadLevel("GameOver");
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

	float getHitPoints ()
	{
		return hitPoints;
	}

	void playerHPUp()
	{
		//hitPoints += hitPoints * 0.1f;
		currentHitPoints = hitPoints;
	}

	void playerHPMaxUp()
	{
		hitPoints += hitPoints * 0.1f;
		currentHitPoints = hitPoints;
	}

	void moreDamageToEnemy ()
	{
		damageToEnemy += 25f;
	}


}
