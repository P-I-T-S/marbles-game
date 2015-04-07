using UnityEngine;
using System.Collections;

/**
 * Author: Duncan Dufva
 **/

public class SwitchController : MonoBehaviour {

	// Use this for initialization

    public Sprite lockSprite;
    public Sprite unlockSprite;
    public bool isLocked;
    private bool inTrigger;
    public GameObject toggleObject;
	void Start () {
        inTrigger = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (inTrigger && Input.GetKeyDown(KeyCode.E)) //Allows player to toggle switch on and off
        {
            this.isLocked = !this.isLocked;
            lockUnlock();
        }
	}

    void lockUnlock()
    {
        if (toggleObject != null) //If there's actually something to toggle
        {
            //All "unlockable" objects contain a method called "ToggleUnlock"
            //Triggering this will change their lock state and make them open/close or start/stop movement
            toggleObject.SendMessage("ToggleUnlock");
        }

        //if (isLocked) //Swaps out sprites to show respective states
        //{
        //    GetComponent<SpriteRenderer>().sprite = lockSprite;
        //}
        //else
        //{
        //    GetComponent<SpriteRenderer>().sprite = unlockSprite;
        //}
    }

    void OnTriggerEnter(Collider other) //Opted to do this here ra6ther than in the player's script.
        //Seemed like an easier option.
    {
        if (other.tag == "Player")
        {
            inTrigger = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inTrigger = false;
        }
    }
}
