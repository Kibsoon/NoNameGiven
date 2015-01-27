using System.Threading;
using UnityEngine;
using System.Collections;

public class DamageHandler: MonoBehaviour
{
	public float invulnPeriod = 0;
	public int health = 2;
	float invulnTimer = 0;
	int correctLayer;
    public static int numberOfEnemies = 7;

	void Start() {
		correctLayer = gameObject.layer;
	}

	void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Wall")
        {
            return;
        }
	    if (other.gameObject.tag == "Box" && gameObject.tag == "Bullet")
	    {
	        Destroy(gameObject);
	    }
        else
        {
            if (other.gameObject.tag != "Box")
            {
                health--;
                if (other.gameObject.tag == "Bullet")
                {
                    Destroy(other.gameObject);
                }
            }
        }
	}

	void OnTriggerEnter2D(Collider2D other) {
		/*if (other.tag == "Wall"){
			Debug.Log ("wall");
			return;
		}
		health --;
		invulnTimer = invulnPeriod;
		gameObject.layer = 10;*/
	}

	void Update(){
		invulnTimer -= Time.deltaTime;
		if (invulnTimer <= 0) {
			gameObject.layer = correctLayer;
		}

		if (health <= 0) {
			Die();
		}
	}

	void Die() {    
	    if (gameObject.tag == "User")
	    {
            Destroy(gameObject);
	        Application.LoadLevel("GameOver");
	    }
        else if (gameObject.name == "Enemy")
	    {
            audio.Play();
	        Destroy(gameObject);
	        numberOfEnemies--;
	    }
	    else
	    {
            Destroy(gameObject);
	    }
	    if (numberOfEnemies == 0)
	    {
	        //Application.LoadLevel("YouWon");

			Destroy ( GameObject.Find("GameObjectForGameHold"));
	    }
	}


}
