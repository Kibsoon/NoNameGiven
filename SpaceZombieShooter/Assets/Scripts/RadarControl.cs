using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RadarControl : MonoBehaviour {

   
    Transform myTransform;

    private GameObject[] enemyObj;

	// Use this for initialization
	void Start () 
    {
        Awake();
       // enemies = new List<EnemyControl>();
	}
	
	// Update is called once per frame
    void Update()
    {
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        myTransform.LookAt(GetClosestEnemy(enemies));
    }

    Transform GetClosestEnemy(GameObject[] enemies)
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (GameObject t in enemies)
        {
            if(t!=null)
            {
                float dist = Vector3.Distance(t.transform.position, currentPos);
                if (dist < minDist && t.renderer.isVisible)
                {
                    tMin = t.transform;
                    minDist = dist;
                }
            }
            
        }
        return tMin ?? myTransform;
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
