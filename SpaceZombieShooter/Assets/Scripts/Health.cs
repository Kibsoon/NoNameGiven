﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Health : MonoBehaviour {

	public float hitPoints = 100f;
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
		//Debug.Log ("Enemy died");
		if(gameObject.tag == "Enemy" || gameObject.tag == "Friend")
		{
			Instantiate(destroyFX, this.transform.position, this.transform.rotation);
			Destroy (gameObject);
		}

	}



}
