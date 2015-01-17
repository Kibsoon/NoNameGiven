using UnityEngine;
using System.Collections;

public class PointsManager : MonoBehaviour {

	public GUIText scorePointsGUI;
	private float points = 0f;
	public float pointsForEnemy1 = 50f;
	public float pointsForEnemy2 = 50f;
	public float pointsForEnemy3 = 200f;

	// Use this for initialization
	void Start () {
	
	}


	void addPoints(string deadObjectName)
	{

		if(deadObjectName == "Enemy1(Clone)") 		points = points + pointsForEnemy1;
		else if(deadObjectName == "Enemy2(Clone)") 	points = points + pointsForEnemy2;
		else if(deadObjectName == "Enemy3(Clone)") 	points = points + pointsForEnemy3;


		scorePointsGUI.text = "Score: " + points;
	}

}
