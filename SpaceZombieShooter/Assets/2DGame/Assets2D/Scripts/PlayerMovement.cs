 using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float maxSpeed = 5f;
	public float rotSpeed = 180f;
	float shipBoundaryRadius = 0.5f;
    protected Animator animator;

	// Use this for initialization
	void Start ()
	{
	    animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		Quaternion rot = transform.rotation;
		float z = rot.eulerAngles.z;
		z -= Input.GetAxis ("Horizontal2D") * rotSpeed * Time.deltaTime;
		rot = Quaternion.Euler (0, 0, z);
		transform.rotation = rot;

		Vector3 pos = transform.position;
		Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical2D") * maxSpeed * Time.deltaTime,0);
		pos += rot * velocity;
        if (!Input.GetAxis("Horizontal2D").Equals(0) || !Input.GetAxis("Vertical2D").Equals(0))
	    {
            animator.SetBool("Walking", true);
	    }
        else
        {
            animator.SetBool("Walking", false);
        }
		/*if (pos.y + shipBoundaryRadius > Camera.main.orthographicSize) {
			pos.y = Camera.main.orthographicSize - shipBoundaryRadius;
		}
		if (pos.y - shipBoundaryRadius < -Camera.main.orthographicSize) {
			pos.y = -Camera.main.orthographicSize + shipBoundaryRadius;
		}

		float screenRatio = (float) Screen.width / (float) Screen.height;
		float widthOrtho = Camera.main.orthographicSize * screenRatio;

		if (pos.x + shipBoundaryRadius > Camera.main.orthographicSize) {
			pos.x = widthOrtho - shipBoundaryRadius;
		}
		if (pos.x - shipBoundaryRadius < -Camera.main.orthographicSize) {
			pos.x = widthOrtho + shipBoundaryRadius;
		} */

		transform.position = pos;
	}
}
