using UnityEngine;
using System.Collections;

public class cameraScript : MonoBehaviour {

	public Transform player;
	public float distanceFromPlayer;
	public float turnSpeed = 4f;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = new Vector3 (player.position.x, player.position.y + distanceFromPlayer, player.position.z - distanceFromPlayer);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 moveToPosition = Vector3.zero;

//		moveToPosition.z = player.position.z - distanceFromPlayer;
//		moveToPosition.x = player.position.x;
//		moveToPosition.y = player.position.y + distanceFromPlayer;
//
//		transform.position = moveToPosition;


	}
	void LateUpdate()
	{
		offset = Quaternion.AngleAxis (Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
		transform.position = player.position + offset;
		transform.LookAt(player.position);
	}
}
