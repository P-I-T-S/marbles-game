using UnityEngine;
using System.Collections;
/*
 * This script is for playing the rolling sound 
 * when the marble is rolling. It increases in pitch
 * when the marble is rolling faster.
 */
public class AudioMarble : MonoBehaviour {
	public AudioClip rolling;
    public AudioClip gem;
	private bool isPlaying = false;
	private bool isGrounded = false;
	float distToGround;
	BoxCollider collider;

	void Start(){
		collider = GetComponentInChildren<BoxCollider> ();
		distToGround = collider.bounds.extents.y;
	}

	void Update () {

		float marbleVelocity = GetComponent<Rigidbody>().velocity.magnitude;
        GetComponent<AudioSource>().pitch = (marbleVelocity / 100) * 9.09f;
		isGrounded = IsGrounded();
		if (marbleVelocity > 0.5f && !isPlaying && isGrounded) {
			GetComponent<AudioSource> ().Play ();
			isPlaying = true;
		}
		else if(marbleVelocity < 0.5f || !isGrounded){
			GetComponent<AudioSource> ().Pause();
		}
		if (!(GetComponent<AudioSource> ().isPlaying)) {
			isPlaying = false;
		}
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Gem")
        {
            GetComponent<AudioSource>().pitch = 0.81f;
            GetComponent<AudioSource>().PlayOneShot(gem);
        }
    }

	public bool IsGrounded() 
	{
		return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.2f);
	}

}
