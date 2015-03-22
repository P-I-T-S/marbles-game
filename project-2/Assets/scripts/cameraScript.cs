using UnityEngine;
using System.Collections;

public class cameraScript : MonoBehaviour {

	public Transform player;
	public float distanceFromPlayer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 moveToPosition = Vector3.zero;

		moveToPosition.z = player.position.z - distanceFromPlayer;
		moveToPosition.x = player.position.x;
		moveToPosition.y = player.position.y + distanceFromPlayer;

		transform.position = moveToPosition;
	}
}
