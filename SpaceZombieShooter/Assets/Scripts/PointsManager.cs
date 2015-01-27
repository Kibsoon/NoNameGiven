using UnityEngine;
using System.Collections;

public class PointsManager : MonoBehaviour {

	public GUIText scorePointsGUI;
	private float points = 0f;
	public float pointsForEnemy1 = 50f;
	public float pointsForEnemy2 = 50f;
	public float pointsForEnemy3 = 200f;
	public float pointsForBoss = 1000f;


	private float money = 0f;
	public GUIText MoneyGUI;

	// Use this for initialization
	void Start () {
	
	}
	void Update () 
	{
		if(GameObject.Find ("Shop"))
			GameObject.Find ("Shop").SendMessageUpwards ("setMoney", money, SendMessageOptions.DontRequireReceiver);
	}

	void addPoints(string deadObjectName)
	{

		if(deadObjectName == "Enemy1(Clone)") 		points = points + pointsForEnemy1;
		else if(deadObjectName == "Enemy2(Clone)") 	points = points + pointsForEnemy2;
		else if(deadObjectName == "Enemy3(Clone)") 	points = points + pointsForEnemy3;
		else if(deadObjectName == "Boss(Clone)") 	points = points + pointsForBoss;


		scorePointsGUI.text = "Score: " + points;


		// MONEY
		if(deadObjectName == "Enemy1(Clone)") 		money = money + pointsForEnemy1/10f;
		else if(deadObjectName == "Enemy2(Clone)") 	money = money + pointsForEnemy2/10f;
		else if(deadObjectName == "Enemy3(Clone)") 	money = money + pointsForEnemy3/10f;
		else if(deadObjectName == "Boss(Clone)") 	money = money + pointsForBoss/10f;

		MoneyGUI.text = "Money: " + money + "$";

		//GameObject.Find ("Shop").SendMessageUpwards ("setMoney", money, SendMessageOptions.DontRequireReceiver);
	}

	void setMoney(float newMoney)
	{
		money = newMoney;
		MoneyGUI.text = "Money: " + money + "$";
	}

}
