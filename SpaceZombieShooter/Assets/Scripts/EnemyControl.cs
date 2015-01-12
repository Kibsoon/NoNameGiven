using UnityEngine;
using System.Collections;

public class EnemyControl : MonoBehaviour {

    public float speed = 1.0f;
	public int properlyDistanceBetweenEnemyAndPalyer = 30;
	public int distanceToObject = 5;
	public float rotationSpeed = 0.5f;

    private GameObject target;
    private GameObject player;
    private GameObject camera;
    private Transform myTransform;
    private bool shooting;

    public bool Shooting
    {
        get { return shooting; }
    }

	// Use this for initialization
	void Start () 
    {
        target = GameObject.FindWithTag("Friend");
        player = GameObject.FindWithTag("Player");
        camera = GameObject.FindWithTag("MainCamera");
        shooting = false;
        Awake();

	}
	

	// Update is called once per frame
	void Update () 
    {
        if (!target || !player)
            return;

      //  var speed = 1.0f;
        var targetDistance = Vector3.Distance(myTransform.position,target.transform.position);
        var playerDistance = Vector3.Distance(myTransform.position, player.transform.position);

        if(IsProperlyDistance(playerDistance))
        {
			if (objectIsTooClose (myTransform, player.transform))
				return;

			LookAt(player.transform);
            shooting = true;
            myTransform.position += (GetDelta(player.transform) * speed * Time.deltaTime);
            return;
        }



		if (objectIsTooClose (myTransform, target.transform))
			return;

        LookAt(target.transform);
        shooting = false;
        myTransform.position += (GetDelta(target.transform) * speed * Time.deltaTime);
	}

    void Awake()
    {
        myTransform = transform;
    }

    bool IsProperlyDistance(float distance)
    {
        if (distance <= properlyDistanceBetweenEnemyAndPalyer)
            return true;
        return false;
    }

    Vector3 GetDelta(Transform transform)
    {
        return transform.position - myTransform.position;
    }

    Vector3 LookAt(Transform transform)
    {
		var vector = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		var rotation = Quaternion.LookRotation (transform.position - myTransform.position);
		myTransform.rotation = Quaternion.Slerp(myTransform.rotation, rotation, rotationSpeed);
		return myTransform.position;
    }


	bool objectIsTooClose(Transform playerOrBase, Transform enemy)
	{

		float x = Mathf.Max(playerOrBase.position.x, enemy.position.x) - Mathf.Min (playerOrBase.position.x, enemy.position.x);
		float y = Mathf.Max(playerOrBase.position.y, enemy.position.y) - Mathf.Min (playerOrBase.position.y, enemy.position.y);
		float z = Mathf.Max(playerOrBase.position.z, enemy.position.z) - Mathf.Min (playerOrBase.position.z, enemy.position.z);

		if(x < distanceToObject && y < distanceToObject && z < distanceToObject)
			return true;

		return false;
	}


}


