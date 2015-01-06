using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class EnemyShooting : MonoBehaviour
    {
        private float coolDown = 0f; // 
        public float fireRate = 0f; // time between shooting

        // checks to see if we're actually firing
        public bool IsFiring { get; set; }

        // firing point transforms for launching projectiles
        public Transform leftFirePoint;
        public Transform rightFirePoint;

        // our projectile object
        public GameObject laserPrefab;

        public AudioSource fireFXSound;

        // Use this for initialization
        void Start()
        {
            IsFiring = false;
        }

        // Update is called once per frame
        void Update()
        {
            
            coolDown -= Time.deltaTime;

            if (IsFiring)
            {
                // player has initiated shooting laser
                Fire();
            }


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
            GameObject.Instantiate(laserPrefab, leftFirePoint.position, leftFirePoint.rotation);
            GameObject.Instantiate(laserPrefab, rightFirePoint.position, rightFirePoint.rotation);

            coolDown = fireRate;

        }
    }
}
