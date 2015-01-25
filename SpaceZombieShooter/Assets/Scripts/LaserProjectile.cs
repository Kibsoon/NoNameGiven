using UnityEngine;
using System.Collections;

public class LaserProjectile : MonoBehaviour {


	public float speed = 2f; // speed of laser
	public int damage = 25; // laser damage to other objects
	private float playerDamage;
	private Transform thisTransform; // cached transform for this projectile
	public Transform laserHitFXPrefab;



	// Use this for initialization
	void Start () 
	{
		thisTransform = transform;


		playerDamage = damage;
						
	}
	

	// Update is called once per frame
	void Update () 
	{
		thisTransform.position += Time.deltaTime * speed * thisTransform.forward;
	}

	void playerAttackUp()
	{
		playerDamage += playerDamage * 0.1f;
	}



	void OnCollisionEnter (Collision collision)
	{

		if(gameObject.name == "Laser(Clone)")
		{
			if (collision.gameObject.tag == "Enemy")
			{
				collision.gameObject.SendMessageUpwards("TakeDamage", playerDamage, SendMessageOptions.DontRequireReceiver);
				
				// destroy laser on collision
				ContactPoint contact = collision.contacts[0]; 	// point of collision
				Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
				Vector3 pos = contact.point;
				Instantiate (laserHitFXPrefab, pos, rot);
				Destroy(gameObject);
			}
		}



		if (collision.gameObject.tag == "Friend" || collision.gameObject.tag == "Player")
		{
			collision.gameObject.SendMessageUpwards("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);

			// destroy laser on collision
			ContactPoint contact = collision.contacts[0]; 	// point of collision
			Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
			Vector3 pos = contact.point;
			Instantiate (laserHitFXPrefab, pos, rot);
			Destroy(gameObject);
		}





	}


}
