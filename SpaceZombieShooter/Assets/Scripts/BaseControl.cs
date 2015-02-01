using UnityEngine;
using System.Collections;

public class BaseControl : MonoBehaviour {

	public GUIText hpGUI;
	public GUIText ZombiesInBaseGUI;
	private int zombiesNr;
	public GUIText ZombieWarningGUI;
	public int zombiesToEndWarning = 10;
	public int zombiesToEnd = 30;

	private Transform myTransform;
	private GameObject player;
	public int distanceToPlayer = 30;

	public int tooFaraway = 150;
	public int tooFarawayWarning = 100;
	public GUIText tooFarawayWarningGUI;


	// Use this for initialization
	void Start () 
	{
		zombiesNr = 0;
		ZombiesInBaseGUI.text = "Zombies: " + zombiesNr + "/" + zombiesToEnd;

		player = GameObject.FindWithTag("Player");
		myTransform = transform;
	}

	void addZombiesInBase()
	{
		if (ZombiesInBaseGUI != null || ZombieWarningGUI != null) 
		{
			zombiesNr++;
			ZombiesInBaseGUI.text = "Zombies: " + zombiesNr + "/" + zombiesToEnd;

			if(zombiesNr >= zombiesToEndWarning)
			{
				ZombieWarningGUI.text = "Warning, zombies in base!";
			}
			else ZombieWarningGUI.text = " ";


			if(zombiesNr >= zombiesToEnd)
			{
				GameObject.Find("SpaceBase").SendMessageUpwards("TakeDamage", 999999, SendMessageOptions.DontRequireReceiver);
				//Application.LoadLevel("GameOver");
			}
			
		}
	}


	void showCurrentHitPoints()
	{
		if (hpGUI != null) 
		{
			
			GameObject SpaceBase = GameObject.Find ("SpaceBase");
			Health hp = SpaceBase.GetComponent<Health> ();
			
			hpGUI.text = "SpaceBase HP: " + hp.currentHitPoints.ToString () + "/" + hp.hitPoints.ToString ();
			//ToString( hp.currentHitPoints);
			GameObject.Find ("HUD").SendMessageUpwards("setSpaceBaseHPGUITexture", hp.currentHitPoints/hp.hitPoints, SendMessageOptions.DontRequireReceiver);

		}
	}




	bool IsProperlyDistance(float distance)
	{
		if (distance <= distanceToPlayer)
			return true;
		return false;
	}




	// Update is called once per frame
	void Update () 
	{
		if(!player)
			return;

		showCurrentHitPoints ();


		if (GameObject.Find ("GameObjectForGameHold")) 
		{
			player.SendMessageUpwards("stopEngines", SendMessageOptions.DontRequireReceiver);
			//	player.SetActive(true);
		}



		var playerDistance = Vector3.Distance(myTransform.position, player.transform.position);


		if(IsProperlyDistance(playerDistance))
		{
			if(ZombieWarningGUI.text == "Warning, zombies in base!" ||
			   ZombieWarningGUI.text == "Warning, zombies in base! Press F to defeat them!" )
			{
				ZombieWarningGUI.text = "Warning, zombies in base! Press F to defeat them!";

				if (Input.GetKeyDown ("f")) 
				{
					player.SendMessageUpwards("stopEngines", SendMessageOptions.DontRequireReceiver);

					if(Random.Range (0, 200) < 100)
						Application.LoadLevelAdditive("2DShooter 1");
					else
						Application.LoadLevelAdditive("2DShooter 2");

					zombiesNr = 0;
					ZombiesInBaseGUI.text = "Zombies: " + zombiesNr + "/" + zombiesToEnd;
				}

			}
			else ZombieWarningGUI.text = " ";
		}
		else if(zombiesNr >= zombiesToEndWarning)
			ZombieWarningGUI.text = "Warning, zombies in base!";
		else ZombieWarningGUI.text = " ";




		if (!(playerDistance <= tooFarawayWarning))
						tooFarawayWarningGUI.text = "You are too far away, get back!";
		else 
			tooFarawayWarningGUI.text = " ";
		if(!(playerDistance <= tooFaraway))
			player.SendMessageUpwards("TakeDamage", 999999, SendMessageOptions.DontRequireReceiver);
			//Application.LoadLevel("GameOver");

	}
}
