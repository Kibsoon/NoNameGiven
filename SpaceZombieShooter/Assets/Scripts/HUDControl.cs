using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HUDControl : MonoBehaviour {

	private List<GameObject> playerHPGui = new List<GameObject>();
	private List<GameObject> spaceBaseHPGui = new List<GameObject>();
	private List<GameObject> speedValueGui = new List<GameObject>();

	// Use this for initialization
	void Start () 
	{
		//player
		for(int i=1; i<9; i++)
		{
			playerHPGui.Insert(i-1, GameObject.Find("PlayerHP" + i));
		}

		foreach(GameObject PHp in playerHPGui)
		{
			PHp.SetActive(false);
		}
		playerHPGui[0].SetActive(true);



		//base
		for(int i=1; i<9; i++)
		{
			spaceBaseHPGui.Insert(i-1, GameObject.Find("SpaceBaseHP" + i));
		}
		
		foreach(GameObject SBHp in spaceBaseHPGui)
		{
			SBHp.SetActive(false);
		}
		spaceBaseHPGui[0].SetActive(true);



		//speed
		for(int i=1; i<10; i++)
		{
			speedValueGui.Insert(i-1, GameObject.Find("SpeedValue" + i));
		}
		
		foreach(GameObject SHp in speedValueGui)
		{
			SHp.SetActive(false);
		}
		speedValueGui[8].SetActive(true);

	}



	void setPlayerHPGUITexture(float hp)
	{
		if(hp >= 0.9)
		{
			playerHPGUIActiveFalse();
			playerHPGui[0].SetActive(true);
		}
		if(hp >= 0.8 && hp < 0.9)
		{
			playerHPGUIActiveFalse();
			playerHPGui[1].SetActive(true);
		}
		if(hp >= 0.7 && hp < 0.8)
		{
			playerHPGUIActiveFalse();
			playerHPGui[2].SetActive(true);
		}
		if(hp >= 0.6 && hp < 0.7)
		{
			playerHPGUIActiveFalse();
			playerHPGui[3].SetActive(true);
		}
		if(hp >= 0.5 && hp < 0.6)
		{
			playerHPGUIActiveFalse();
			playerHPGui[4].SetActive(true);
		}
		if(hp >= 0.4 && hp < 0.5)
		{
			playerHPGUIActiveFalse();
			playerHPGui[5].SetActive(true);
		}
		if(hp >= 0.2 && hp < 0.4)
		{
			playerHPGUIActiveFalse();
			playerHPGui[6].SetActive(true);
		}
		if(hp < 0.2)
		{
			playerHPGUIActiveFalse();
			playerHPGui[7].SetActive(true);
		}
	}




	void setSpaceBaseHPGUITexture(float hp)
	{
		if(hp >= 0.9)
		{
			spaceBaseHPGUIActiveFalse();
			spaceBaseHPGui[0].SetActive(true);
		}
		if(hp >= 0.8 && hp < 0.9)
		{
			spaceBaseHPGUIActiveFalse();
			spaceBaseHPGui[1].SetActive(true);
		}
		if(hp >= 0.7 && hp < 0.8)
		{
			spaceBaseHPGUIActiveFalse();
			spaceBaseHPGui[2].SetActive(true);
		}
		if(hp >= 0.6 && hp < 0.7)
		{
			spaceBaseHPGUIActiveFalse();
			spaceBaseHPGui[3].SetActive(true);
		}
		if(hp >= 0.5 && hp < 0.6)
		{
			spaceBaseHPGUIActiveFalse();
			spaceBaseHPGui[4].SetActive(true);
		}
		if(hp >= 0.4 && hp < 0.5)
		{
			spaceBaseHPGUIActiveFalse();
			spaceBaseHPGui[5].SetActive(true);
		}
		if(hp >= 0.2 && hp < 0.4)
		{
			spaceBaseHPGUIActiveFalse();
			spaceBaseHPGui[6].SetActive(true);
		}
		if(hp < 0.2)
		{
			spaceBaseHPGUIActiveFalse();
			spaceBaseHPGui[7].SetActive(true);
		}
	}



	void setEnginesValueGUITexture(float value)
	{
		if(value >= 0.9)
		{
			enginesValueGUIActiveFalse();
			speedValueGui[0].SetActive(true);
		}
		if(value >= 0.8 && value < 0.9)
		{
			enginesValueGUIActiveFalse();
			speedValueGui[1].SetActive(true);
		}
		if(value >= 0.7 && value < 0.8)
		{
			enginesValueGUIActiveFalse();
			speedValueGui[2].SetActive(true);
		}
		if(value >= 0.6 && value < 0.7)
		{
			enginesValueGUIActiveFalse();
			speedValueGui[3].SetActive(true);
		}
		if(value >= 0.5 && value < 0.6)
		{
			enginesValueGUIActiveFalse();
			speedValueGui[4].SetActive(true);
		}
		if(value >= 0.4 && value < 0.5)
		{
			enginesValueGUIActiveFalse();
			speedValueGui[5].SetActive(true);
		}
		if(value >= 0.3 && value < 0.4)
		{
			enginesValueGUIActiveFalse();
			speedValueGui[6].SetActive(true);
		}
		if(value >= 0.2 && value < 0.3)
		{
			enginesValueGUIActiveFalse();
			speedValueGui[7].SetActive(true);
		}
		if(value < 0.2)
		{
			enginesValueGUIActiveFalse();
			speedValueGui[8].SetActive(true);
		}
	}






	void playerHPGUIActiveFalse()
	{
		foreach(GameObject PHp in playerHPGui)
		{
			PHp.SetActive(false);
		}
	}
	void spaceBaseHPGUIActiveFalse()
	{
		foreach(GameObject SBHp in spaceBaseHPGui)
		{
			SBHp.SetActive(false);
		}
	}
	void enginesValueGUIActiveFalse()
	{
		foreach(GameObject SHp in speedValueGui)
		{
			SHp.SetActive(false);
		}
	}


}
