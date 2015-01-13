using UnityEngine;
using System.Collections;

public class TowerShooting : MonoBehaviour {

    private float coolDown = 0f; // 
    public float fireRate = 0f; // time between shooting
	public float fireRange = 50f;
	public float speed = 1.0f;



	// turrets movement
	private Vector3 turretVector = new Vector3(0,0,0);
	public int staticDimension = 0; // x = 1, y = 2, z = 3
	public float cornerValue = 100f; // 2 * cornerValue = cube width



    // checks to see if we're actually firing
    private bool isFiring = false;

    // firing point transforms for launching projectiles
    public Transform FirePoint;

    // our projectile object
    public GameObject laserPrefab;
    private GameObject enemy;

    public AudioSource fireFXSound;


    private Transform myTransform;

    // Use this for initialization
    void Start()
    {
        isFiring = false;
    }

    // Update is called once per frame
    void Update()
    {
        coolDown -= Time.deltaTime;
        
        enemy = GameObject.FindWithTag("Enemy");
        if (!enemy)
            return;
        var enemyDistance = Vector3.Distance(myTransform.position, enemy.transform.position);
        IsProperlyDistance(enemyDistance);
        
        if (isFiring)
        {
            //Debug.Log("shoot to enemy");
            myTransform.LookAt(enemy.transform);
            Fire();
        }





		// moving on wall

		if(staticDimension == 1)
		{
			turretVector.x = myTransform.position.x;
			turretVector.y = enemy.transform.position.y - myTransform.position.y;
			turretVector.z = enemy.transform.position.z - myTransform.position.z;
		}

		if(staticDimension == 2)
		{
			turretVector.x = enemy.transform.position.x - myTransform.position.x;
			turretVector.y = myTransform.position.y;
			turretVector.z = enemy.transform.position.z - myTransform.position.z;
		}

		if(staticDimension == 3)
		{
			turretVector.x = enemy.transform.position.x - myTransform.position.x;
			turretVector.y = enemy.transform.position.y - myTransform.position.y;
			turretVector.z =  myTransform.position.z;
		}



		if(staticDimension == 1)
		{

			if(myTransform.position.y + (turretVector.y * speed * Time.deltaTime) > cornerValue) return;
			if(myTransform.position.y + (turretVector.y * speed * Time.deltaTime) < -cornerValue) return;
			if(myTransform.position.z + (turretVector.z * speed * Time.deltaTime) > cornerValue) return;
			if(myTransform.position.z + (turretVector.z * speed * Time.deltaTime) < -cornerValue) return;
		}
		if(staticDimension == 2)
		{
			if(myTransform.position.x + (turretVector.x * speed * Time.deltaTime) > cornerValue) return;
			if(myTransform.position.x + (turretVector.x * speed * Time.deltaTime) < -cornerValue) return;

			if(myTransform.position.z + (turretVector.z * speed * Time.deltaTime) > cornerValue) return;
			if(myTransform.position.z + (turretVector.z * speed * Time.deltaTime) < -cornerValue) return;
		}
		if(staticDimension == 3)
		{
			if(myTransform.position.x + (turretVector.x * speed * Time.deltaTime) > cornerValue) return;
			if(myTransform.position.x + (turretVector.x * speed * Time.deltaTime) < -cornerValue) return;
			if(myTransform.position.y + (turretVector.y * speed * Time.deltaTime) > cornerValue) return;
			if(myTransform.position.y + (turretVector.y * speed * Time.deltaTime) < -cornerValue) return;

		}



		myTransform.position += (turretVector * speed * Time.deltaTime);


    }
	

    void Awake()
    {
        myTransform = transform;
    }

    void IsProperlyDistance(float distance)
    {
		var properlyDistanceBetweenEnemyAndPalyer = fireRange;
        
        if (distance <= properlyDistanceBetweenEnemyAndPalyer)
            isFiring = true;
        else isFiring = false;
    }

    Vector3 LookAt(Transform transform)
    {
        //var distance = 600.0f;
        var vector = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        var rotation = Quaternion.FromToRotation(transform.position, myTransform.position);
        myTransform.rotation = Quaternion.Slerp(myTransform.rotation, rotation, Time.deltaTime);
        return myTransform.position;
    }


    void Fire()
    {
        if (coolDown > 0)
        {
            return; // do not fire
        }

        // sound FX when firing
        if (fireFXSound != null)
        {
            fireFXSound.Play();
        }
        GameObject.Instantiate(laserPrefab, FirePoint.position, FirePoint.rotation);

        coolDown = fireRate;

    }
}
