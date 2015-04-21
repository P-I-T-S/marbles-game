using UnityEngine;
using System.Collections;

public class LaunchScript : MonoBehaviour {

	public float force;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other)
	{
	
	Vector3 dir = transform.up;
		if (other.tag == "Player")
		{
			other.GetComponent<Rigidbody>().AddForce((dir) * force, ForceMode.Impulse);
		}
	}
}
