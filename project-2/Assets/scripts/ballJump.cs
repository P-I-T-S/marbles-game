using UnityEngine;
using System.Collections;

public class ballJump : MonoBehaviour {
	public float jumpForce;
	Rigidbody rigidbody;
	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			Vector3 jump = new Vector3(0, jumpForce, 0);
			rigidbody.AddForce(jump);
		}
	}
}
