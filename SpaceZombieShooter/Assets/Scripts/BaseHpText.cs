using UnityEngine;
using System.Collections;

public class BaseHpText : MonoBehaviour {

	public GUIText hpGUI;

	// Use this for initialization
	void Start () {
	
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

	// Update is called once per frame
	void Update () 
	{
		showCurrentHitPoints ();
	}
}
