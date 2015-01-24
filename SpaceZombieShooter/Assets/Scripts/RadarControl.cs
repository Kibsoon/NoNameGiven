using UnityEngine;
using System.Collections;

public class RadarControl : MonoBehaviour {

    GameObject[] enemies;
    GameObject nearestEnemy;
    Transform myTransform;

	// Use this for initialization
	void Start () 
    {
        Awake();
	}
	
	// Update is called once per frame
	void Update () 
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float targetDistance = Vector3.Distance(myTransform.position, enemies[0].transform.position);
        nearestEnemy = enemies[0];

        foreach (var enemy in enemies)
        {
            var distance = Vector3.Distance(myTransform.position, enemy.transform.position);
            if (targetDistance > distance)
                nearestEnemy = enemy;
        }

     //   myTransform.LookAt(nearestEnemy.transform);
        LookAt(nearestEnemy.transform);
	
	}


    void LookAt(Transform transform)
    {
        var rotationSpeed = 1.0f;
        var vector = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        var rotation = Quaternion.LookRotation(transform.position - myTransform.position);
        myTransform.rotation = Quaternion.Slerp(myTransform.rotation, rotation, rotationSpeed);
    }


    void Awake()
    {
        myTransform = transform;
    }
}
