using UnityEngine;
using System.Collections;

public class ballMovement : MonoBehaviour {
	public float speed = 5f;
	Rigidbody rigidbody;
	float xInput;
	float zInput;
	private Transform mainCamera;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody> ();
		mainCamera = Camera.main.transform;
		rigidbody.maxAngularVelocity = 15;
	}
	// Update is called once per frame
	void Update () {
		//G et the user input
		xInput = Input.GetAxis ("Horizontal");
		zInput = Input.GetAxis ("Vertical");
		Vector3 inputDir = new Vector3 (xInput, 0, zInput);

		// Get direction the camera is faceing, transforming it to global vectors
		Vector3 forwardDirection = mainCamera.transform.TransformDirection (Vector3.forward);
		Vector3 righDirection = mainCamera.transform.TransformDirection (Vector3.right);

		// Set the direction to move base on the direction the camera is faceing and the user input
		Vector3 moveDirection = (righDirection * inputDir.x) + (forwardDirection * inputDir.z);
		// Remove the vertical component
		moveDirection.y = 0;
		//Normonlize the vector so all magnitudes are the same
		moveDirection.Normalize ();

		// Move the ball, multiplying by the speed value
		rigidbody.AddForce (moveDirection * speed);
	}
}
