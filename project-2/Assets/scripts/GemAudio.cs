using UnityEngine;
using System.Collections;

public class GemAudio : MonoBehaviour {
	public AudioClip gemPickup;
	public AudioClip complete;
	public AudioClip levelComplete;
	public bool isLevelComplete = false;

	void Start(){
		isLevelComplete = false;
		Debug.Log (isLevelComplete);
	}
	void Update(){
		if (isLevelComplete) {
            GetComponent<AudioSource>().volume = 0.3f;
			GetComponent<AudioSource>().PlayOneShot(levelComplete);
			isLevelComplete = false;
		}
	}
	void OnTriggerEnter(Collider coll){
		AudioSource thisAudioSource = GetComponent<AudioSource>();
		thisAudioSource.volume = 0.2f;
		if (coll.gameObject.tag == "Player") {
			if(GameObject.FindGameObjectsWithTag("Gem").Length == 1 && this.gameObject.tag == "Gem"){
				AudioSource.PlayClipAtPoint(complete, GetComponent<Transform>().position);
				GameObject.Destroy(GameObject.FindGameObjectWithTag("Gem"));
			}
			//If the player collides with the finish platform, the levelcomplete music will play
			else if(isLevelComplete && this.gameObject.tag == "Finish"){
				GetComponent<AudioSource>().PlayOneShot(levelComplete);
				isLevelComplete = false;
			}
			else if(this.gameObject.tag == "Gem"){
				AudioSource.PlayClipAtPoint(gemPickup, GetComponent<Transform>().position);
				GameObject.Destroy(this.gameObject);
			}
		}
	}

	public void setLevelComplete(){
		isLevelComplete = true;
	}
}
