using UnityEngine;
using System.Collections;

public class OnCollisionDestroy : MonoBehaviour {
	
	public GameObject destroyFX;
	
	// Use this for initialization
	void Start () {
		
	}
	void Update () 
	{

	}
	
	
	void OnCollisionEnter (Collision collision)
	{

        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Friend" || collision.gameObject.tag == "Player")
		{
			collision.gameObject.SendMessageUpwards("TakeDamage", 9999, SendMessageOptions.DontRequireReceiver);
			
			// destroy object on collision
			ContactPoint contact = collision.contacts[0]; 	// point of collision
			Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
			Vector3 pos = contact.point;
			Instantiate (destroyFX, pos, rot);
			Destroy(gameObject);
		}
		
		
	}
	
	
}
