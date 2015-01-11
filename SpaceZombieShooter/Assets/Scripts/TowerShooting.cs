using UnityEngine;
using System.Collections;

public class TowerShooting : MonoBehaviour {

    private float coolDown = 0f; // 
    public float fireRate = 0f; // time between shooting

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
            Debug.Log("shoot to enemy");
            myTransform.LookAt(enemy.transform);
            Fire();
        }
    }

    void Awake()
    {
        myTransform = transform;
    }

    void IsProperlyDistance(float distance)
    {
        var properlyDistanceBetweenEnemyAndPalyer = 50f;
        
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
