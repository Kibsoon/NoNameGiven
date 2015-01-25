using UnityEngine;
using System.Collections;

public class WallAndBulletHandler : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {           
            Destroy(other.gameObject);
        }
    }

}
