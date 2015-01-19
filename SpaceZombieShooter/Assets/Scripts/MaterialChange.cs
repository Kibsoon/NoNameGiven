using UnityEngine;
using System.Collections;

public class MaterialChange : MonoBehaviour {

	public Texture texture;

	// Use this for initialization
	void Start () 
	{
		if(!texture)
			renderer.material.mainTexture = null;

		renderer.material.mainTexture = texture;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
