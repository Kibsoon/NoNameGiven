using UnityEngine;
using System.Collections;

public class EnemyControl : MonoBehaviour {

    public float speed = 1.0f;
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
            LookAt(player.transform);
            shooting = true;
            myTransform.position += (GetDelta(player.transform) * speed * Time.deltaTime);
            return;
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
        var properlyDistanceBetweenEnemyAndPalyer = 30f;

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
        //var distance = 600.0f;
        var vector = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        var rotation = Quaternion.FromToRotation(transform.position, myTransform.position);
        myTransform.rotation = Quaternion.Slerp(myTransform.rotation, rotation, Time.deltaTime);
        return myTransform.position;
    }

}
