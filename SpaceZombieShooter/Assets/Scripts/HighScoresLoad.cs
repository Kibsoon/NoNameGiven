using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class HighScoresLoad : MonoBehaviour {

	private List<float> highscores = new List<float>();

	private string path = @"scores.txt";

	public  GUIText value1;
	public  GUIText value2;
	public  GUIText value3;
	public  GUIText value4;
	public  GUIText value5;
	public  GUIText value6;
	public  GUIText value7;


	protected FileInfo theSourceFile = null;
	protected StreamReader reader = null;
	protected string text = " "; // assigned to allow first line to be read below


	// Use this for initialization
	void Start () 
	{

		theSourceFile = new FileInfo (path);
		reader = theSourceFile.OpenText();

		while(text!= null)
		{
			text = reader.ReadLine();

			if(text != null)
			{
				highscores.Add( float.Parse(text) );
			}

		}


		highscores.Sort( delegate (float t1, float t2) 
		                { return (t2.CompareTo(t1)); } 
		);



		// empty rows
		if(highscores.Count < 7)
		{
			int x = 7 - highscores.Count;
			for(int i=0; i<x; i++)
			{
				highscores.Add( 0 );
				
			}
		}


		value1.text = highscores [0].ToString();
		value2.text = highscores [1].ToString();
		value3.text = highscores [2].ToString();
		value4.text = highscores [3].ToString();
		value5.text = highscores [4].ToString();
		value6.text = highscores [5].ToString();
		value7.text = highscores [6].ToString();
			

	}
	

}
