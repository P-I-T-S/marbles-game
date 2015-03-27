using UnityEngine;
using System.Collections;

public class ballJump : MonoBehaviour {
	float distToGround;
	public float jumpForce = 250f;
	BoxCollider collider;
	// Use this for initialization
	void Start () {
		collider = GetComponent<BoxCollider> ();
		distToGround = collider.bounds.extents.z;
	}
	bool IsGrounded() 
	{
		return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
	}
	// Update is called once per frame
	void Update () {
		//causes the ball to jump into the air if space bar is pressed (only if ball is grounded)
		if (IsGrounded ()) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				Vector3 jump = new Vector3 (0, jumpForce, 0);
				GetComponentInParent<Rigidbody> ().AddForce (jump);
			}
		}
	}
}
