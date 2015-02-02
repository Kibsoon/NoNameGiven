using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class PointsManager : MonoBehaviour {

	public GUIText scorePointsGUI;
	private float points = 0f;
	public float pointsForEnemy1 = 50f;
	public float pointsForEnemy2 = 50f;
	public float pointsForEnemy3 = 200f;
	public float pointsForBoss = 1000f;
	public float pointsFor2DGame = 1000f;

	public GUIText youLoseGUI;


	private float money = 0f;
	public GUIText MoneyGUI;

	private string path = @"scores.txt";

	// Use this for initialization
	void Start () {
	
	}
	void Update () 
	{
		if(GameObject.Find ("Shop"))
			GameObject.Find ("Shop").SendMessageUpwards ("setMoney", money, SendMessageOptions.DontRequireReceiver);


		if((Input.GetKeyDown ("space") && youLoseGUI.text == "You Lose!!!") 
		   || Input.GetKeyDown(KeyCode.Mouse0) && youLoseGUI.text == "You Lose!!!")
		{



			// tutaj jakis zapis punktow sie da
			//System.IO.File.WriteAllText(@"scores.txt", points.ToString() );


			File.AppendAllText(path, points.ToString() + Environment.NewLine );



			Application.LoadLevel("GameOver");
		}
			
			
	}

	void addPoints(string deadObjectName)
	{

		if(deadObjectName == "Enemy1(Clone)") 		points = points + pointsForEnemy1;
		else if(deadObjectName == "Enemy2(Clone)") 	points = points + pointsForEnemy2;
		else if(deadObjectName == "Enemy3(Clone)") 	points = points + pointsForEnemy3;
		else if(deadObjectName == "Boss(Clone)") 	points = points + pointsForBoss;
		else if(deadObjectName == "game2D") 		points = points + pointsFor2DGame;


		scorePointsGUI.text = "Score: " + points;


		// MONEY
		if(deadObjectName == "Enemy1(Clone)") 		money = money + pointsForEnemy1/10f;
		else if(deadObjectName == "Enemy2(Clone)") 	money = money + pointsForEnemy2/10f;
		else if(deadObjectName == "Enemy3(Clone)") 	money = money + pointsForEnemy3/10f;
		else if(deadObjectName == "Boss(Clone)") 	money = money + pointsForBoss/10f;
		else if(deadObjectName == "game2D") 		money = money + pointsFor2DGame/10f;

		MoneyGUI.text = "Money: " + money + "$";

		//GameObject.Find ("Shop").SendMessageUpwards ("setMoney", money, SendMessageOptions.DontRequireReceiver);
	}

	void setMoney(float newMoney)
	{
		money = newMoney;
		MoneyGUI.text = "Money: " + money + "$";
	}

}
