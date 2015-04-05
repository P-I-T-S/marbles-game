using UnityEngine;
using System.Collections;

public class cameraScript : MonoBehaviour {

	Transform player;

    Transform spawn;
    public GameObject marble;

	public float distanceFromPlayer;
	public float turnSpeed = 4f;
	private Vector3 offset;
    float rotationY = 0f;
    float rotationX = 0f;

	// Use this for initialization
	void Start () {
        spawn = GameObject.FindGameObjectWithTag("Respawn").transform;
        Instantiate(marble, spawn.position, spawn.rotation);

        player = GameObject.FindGameObjectWithTag("Player").transform;

        

		offset = spawn.right * -1 * distanceFromPlayer;
        offset = new Vector3(offset.x, distanceFromPlayer /2, offset.z);

	}

	// Late update is so that the camera can be moved after the player has moved
	void LateUpdate()
	{
        player = GameObject.FindGameObjectWithTag("Player").transform;

        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
        transform.position = player.position + offset;
        transform.LookAt(player.position);

        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * turnSpeed, -Vector3.right) * offset;
        transform.position = player.position + offset;
        transform.LookAt(player.position);

        //offset = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * turnSpeed, -Vector3.right) * offset;
        //Vector3 pos = offset;
        //pos.y = Mathf.Clamp(pos.y, -15f, 15f);
        //offset = pos;
        //transform.position = player.position + offset;
        //Vector3 playerPOS = player.position;
        //playerPOS.y = Mathf.Clamp(playerPOS.y, -15f, 15f);
        //player.position = playerPOS;
        //transform.LookAt(new Vector3(player.position.x, Mathf.Clamp(player.position.y, -15f, 15f), player.position.z));


        //rotationY += Input.GetAxis("Mouse Y") * turnSpeed;
        //rotationY = Mathf.Clamp(rotationY, -45f, 45f);
        //transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
	}
}
