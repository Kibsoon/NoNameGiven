using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class EnemyControl : MonoBehaviour {

    public GameObject Target;
    public GameObject Player;
    private float speed;
    private Transform myTransform;
    private EnemyShooting shooting;

	// Use this for initialization
	void Start () 
    {
        Target = GameObject.FindWithTag("Friend");
        Player = GameObject.FindWithTag("Player");
        Awake();

	}
	

	// Update is called once per frame
	void Update () 
    {
        if (!Target || !Player)
            return;

        speed = 10f;
        var targetDistance = Vector3.Distance(myTransform.position,Target.transform.position);
        var playerDistance = Vector3.Distance(myTransform.position, Player.transform.position);

        if(IsProperlyDistance(playerDistance))
        {
            myTransform.position += (GetDelta(Player.transform) * speed * Time.deltaTime);
            return;
        }

        LookAt(Target.transform);
        myTransform.position += (GetDelta(Target.transform) * speed * Time.deltaTime);
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
      //  var damping = 6.0;
        var rotation = Quaternion.LookRotation(transform.position - myTransform.position);
        myTransform.rotation = Quaternion.Slerp(myTransform.rotation, rotation, Time.deltaTime);
        return myTransform.position;
    }
}
