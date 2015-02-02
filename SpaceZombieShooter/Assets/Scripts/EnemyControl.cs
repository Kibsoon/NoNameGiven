using UnityEngine;
using System.Collections;

public class EnemyControl : MonoBehaviour {

    public float speed = 1.0f;
	public float properlyDistanceBetweenEnemyAndPalyer = 200.0f;
	public int distanceToObject = 5;
	public float rotationSpeed = 0.5f;

	public int chanceToEnter = 80;
	private int randomValueChanceToEnter;

    private GameObject target;
    private GameObject player;
    private GameObject camera;
    private Transform myTransform;
    private PlayerControl playerControl;
    private bool shooting;

    public bool Shooting
    {
        get { return shooting; }
    }

	// Use this for initialization
	void Start () 
    {
        target = GameObject.FindWithTag("Friend");
        player = GameObject.Find("Player");
        camera = GameObject.FindWithTag("MainCamera");
        if(player)
            playerControl = player.GetComponent<PlayerControl>();
        shooting = false;
        Awake();

		randomValueChanceToEnter = Random.Range (0, 100);
	}
	
   
	// Update is called once per frame
	void Update () 
    {
        if (!target || !player || !playerControl)
            return;
        
        var targetDistance = Vector3.Distance(myTransform.position,target.transform.position);
        var playerDistance = Vector3.Distance(myTransform.position, player.transform.position);

        if(IsProperlyDistance(playerDistance))
        {
            if(playerControl.EnginePowerValue <= 0)
                myTransform.LookAt(player.transform);
            else
            {
                var temp = new Vector3(3.0f, 0.0f, 0.0f);
                myTransform.LookAt(player.transform,temp);
            }
            shooting = true;


			if (objectIsTooClose(myTransform, player.transform))
				return;

            myTransform.position += (GetDelta(player.transform) * speed * Time.deltaTime);
            return;
        }



		if(randomValueChanceToEnter > chanceToEnter)
		{
			if (objectIsTooClose (myTransform, target.transform))
			{
				shooting = true;
				return;
			}
		}

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


	void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag == "Friend" )
		{
			//ContactPoint contact = collision.contacts[0]; 	// point of collision
			//Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
			//Vector3 pos = contact.point;
			//Instantiate (destroyObjectFX, pos, rot);
			Destroy(gameObject);

			GameObject.Find ("SpaceBase").SendMessage("addZombiesInBase", SendMessageOptions.DontRequireReceiver);

		}

		if (collision.gameObject.tag == "Player" )
		{
			Destroy(gameObject);
			
			GameObject.Find ("Player").SendMessage("addZombiesInPlayer", SendMessageOptions.DontRequireReceiver);
			
		}


	}
}


