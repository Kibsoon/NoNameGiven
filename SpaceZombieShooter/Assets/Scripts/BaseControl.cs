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

	// Use this for initialization
	void Start () 
	{
		zombiesNr = 0;

		player = GameObject.FindWithTag("Player");
		myTransform = transform;
	}

	void addZombiesInBase()
	{
		if (ZombiesInBaseGUI != null || ZombieWarningGUI != null) 
		{
			zombiesNr++;
			ZombiesInBaseGUI.text = "Zombies: " + zombiesNr;

			if(zombiesNr >= zombiesToEndWarning)
			{
				ZombieWarningGUI.text = "Uwaga, zombie w bazie!";
			}
			else ZombieWarningGUI.text = " ";


			if(zombiesNr >= zombiesToEnd)
			{
				Application.LoadLevel("MainMenuScene");
			}
			
		}
	}


	void showCurrentHitPoints()
	{
		if (hpGUI != null) 
		{
			
			GameObject SpaceBase = GameObject.Find ("SpaceBase");
			Health hp = SpaceBase.GetComponent<Health> ();
			
			hpGUI.text = "SpaceBase HP: " + hp.currentHitPoints.ToString ();
			//ToString( hp.currentHitPoints);
			
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




		var playerDistance = Vector3.Distance(myTransform.position, player.transform.position);


		if(IsProperlyDistance(playerDistance))
		{
			if(ZombieWarningGUI.text == "Uwaga, zombie w bazie!" ||
			   ZombieWarningGUI.text == "Uwaga, zombie w bazie! Naciśnij F żeby obronić bazę!" )
			{
				ZombieWarningGUI.text = "Uwaga, zombie w bazie! Naciśnij F żeby obronić bazę!";

				if (Input.GetKeyDown ("f")) 
				{
					Application.LoadLevel("MainMenuScene");
				}

			}
			else ZombieWarningGUI.text = " ";
		}
		else if(zombiesNr >= zombiesToEndWarning)
			ZombieWarningGUI.text = "Uwaga, zombie w bazie!";
		else ZombieWarningGUI.text = " ";


	}
}
