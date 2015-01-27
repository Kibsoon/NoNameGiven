using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

	public float timeToRespawn = 10f;
	public int spawnPositionRange1 = 20;
	public int spawnPositionRange2 = 30;
	public GameObject enemy1;
	public GameObject enemy2;
	public GameObject enemy3;
	public GameObject boss;

	private GameObject[] enemyTab = new GameObject[4];
	private Vector3 spawnPosition = new Vector3(0,0,0);

	public float spawnShorterTime = 0.01f;
	public int wavesToBreak = 10;
	private int currentWave;
	public int secOfBreak = 20;
	public GUIText WaveNRGUI;
	private int waveNumber;

	// Use this for initialization
	void Start () 
	{
		Screen.showCursor = false; 

		enemyTab[0] = enemy1;
		enemyTab[1] = enemy2;
		enemyTab[2] = enemy3;
		enemyTab[3] = boss;

		StartCoroutine (EnemySpawn() );

		currentWave = 1;

		WaveNRGUI.text = "Wave 1";
		waveNumber = 1;
	}
	
	IEnumerator EnemySpawn()
	{
		while(true)
		{
			var enemyNumber = Random.Range (0, 4); 	// which enemy


			// random position in (-spawnPositionRange2, -spawnPositionRange1) U (spawnPositionRange1, spawnPositionRange2)
			if(Random.Range (0, 200) < 100)
				spawnPosition.x = Random.Range (spawnPositionRange1, spawnPositionRange2);
			else
				spawnPosition.x = Random.Range (-spawnPositionRange2, -spawnPositionRange1);

			if(Random.Range (0, 200) < 100)
				spawnPosition.y = Random.Range (spawnPositionRange1, spawnPositionRange2);
			else 
				spawnPosition.y = Random.Range (-spawnPositionRange2, -spawnPositionRange1);

            if (Random.Range(0, 200) < 100)
				spawnPosition.z = Random.Range (spawnPositionRange1, spawnPositionRange2);
			else
				spawnPosition.z = Random.Range (-spawnPositionRange2, -spawnPositionRange1);



			//Debug.Log ("enemy= "+  enemyNumber + " x= " + spawnPosition.x + " y= " + spawnPosition.y + " z= " + spawnPosition.z);


			Instantiate(enemyTab[enemyNumber], spawnPosition, Quaternion.identity);




			if(currentWave == 0)
			{
				waveNumber++;
				WaveNRGUI.text = "Wave " + waveNumber;
			}

			currentWave++;
			if(currentWave >= wavesToBreak)
			{
				currentWave = 0;

				yield return new WaitForSeconds(secOfBreak);
			}
				
			
			
			timeToRespawn -= spawnShorterTime ;
			Debug.Log("wave " + currentWave);
			if(timeToRespawn > 0)
				yield return new WaitForSeconds(timeToRespawn);
			else
				yield return new WaitForSeconds(0);
		}
	}


}
