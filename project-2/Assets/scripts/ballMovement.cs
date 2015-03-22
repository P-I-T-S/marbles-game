using UnityEngine;
using System.Collections;

public class ballMovement : MonoBehaviour {
	public float speed = 5f;
	Rigidbody rigidbody;
	float xInput;
	float zInput;
	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void Update () {
		xInput = Input.GetAxis ("Horizontal");
		zInput = Input.GetAxis ("Vertical");
		Vector3 moveDir = new Vector3 (xInput, 0, zInput);
		
		//transform.Translate (moveDir * speed * Time.deltaTime);

		rigidbody.AddForce (moveDir * speed);

	}
}
