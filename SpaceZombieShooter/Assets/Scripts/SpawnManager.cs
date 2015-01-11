using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

	public int timeToRespawn = 10;
	public int spawnPositionRange1 = 20;
	public int spawnPositionRange2 = 30;
	public GameObject enemy1;
	public GameObject enemy2;
	public GameObject enemy3;

	private GameObject[] enemyTab = new GameObject[3];
	private Vector3 spawnPosition = new Vector3(0,0,0);

	// Use this for initialization
	void Start () 
	{
		enemyTab[0] = enemy1;
		enemyTab[1] = enemy2;
		enemyTab[2] = enemy3;

		StartCoroutine (EnemySpawn() );
	}
	
	IEnumerator EnemySpawn()
	{
		while(true)
		{
			var enemyNumber = Random.Range (0, 3); 	// which enemy


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
			yield return new WaitForSeconds(timeToRespawn);
		}
	}


}
