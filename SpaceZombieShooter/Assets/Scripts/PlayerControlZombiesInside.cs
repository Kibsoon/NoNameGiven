using UnityEngine;
using System.Collections;

public class PlayerControlZombiesInside : MonoBehaviour {


	public GUIText ZombiesInPlayerGUI;
	private int zombiesNr;
	public GUIText ZombieWarningGUI;
	public int zombiesToEndWarning = 3;
	public int zombiesToEnd = 6;

	private GameObject player;

	// Use this for initialization
	void Start () 
	{
		zombiesNr = 0;
		ZombiesInPlayerGUI.text = "Zombies: " + zombiesNr + "/" + zombiesToEnd;

		player = GameObject.Find ("Player");
	}


	void addZombiesInPlayer()
	{
		if (ZombiesInPlayerGUI != null || ZombieWarningGUI != null) 
		{
			zombiesNr++;
			ZombiesInPlayerGUI.text = "Zombies: " + zombiesNr + "/" + zombiesToEnd;
			
			if(zombiesNr >= zombiesToEndWarning)
			{
				ZombieWarningGUI.text = "Warning, zombies in spaceship! Press G to defeat them!";
			}
			else ZombieWarningGUI.text = " ";
			
			
			if(zombiesNr >= zombiesToEnd)
			{
				Application.LoadLevel("GameOver");
			}
			
		}
	}

	// Update is called once per frame
	void Update () 
	{
		if(!gameObject)
			return;

		if (GameObject.Find ("GameObjectForGameHold")) 
		{
			player.SendMessageUpwards("stopEngines", SendMessageOptions.DontRequireReceiver);
		//	player.SetActive(true);
		}
		else
			player.SendMessageUpwards("startEngines", SendMessageOptions.DontRequireReceiver);


		if(ZombieWarningGUI.text == "Warning, zombies in spaceship! Press G to defeat them!" )
		{
			//ZombieWarningGUI.text = "Uwaga, masz trupy na statku! Naciśnij G żeby obronić bazę!";
				
				if (Input.GetKeyDown ("g")) 
				{
				player.SendMessageUpwards("stopEngines", SendMessageOptions.DontRequireReceiver);

				//Application.LoadLevel("2DShooter");
				Application.LoadLevelAdditive("2DShooter");

				zombiesNr = 0;
				ZombiesInPlayerGUI.text = "Zombies: " + zombiesNr + "/" + zombiesToEnd;
				}
				
		}
		else ZombieWarningGUI.text = " ";

		if(zombiesNr >= zombiesToEndWarning)
			ZombieWarningGUI.text = "Warning, zombies in spaceship! Press G to defeat them!";
		else ZombieWarningGUI.text = " ";


	}
}
