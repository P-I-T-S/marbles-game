using UnityEngine;
using System.Collections;

/**
 * Author: Duncan Dufva
 **/

public class SwitchController : MonoBehaviour {

	// Use this for initialization
    public bool isLocked;
    private bool inTrigger, isMoving;
    public GameObject toggleObject, buttonBase, buttonTop, pressedInLocation;
    private Vector3 _pressedInLocation, defaultPosition, location;
	void Start () {
        inTrigger = false;
        isMoving = true;
        _pressedInLocation = pressedInLocation.transform.position;
        defaultPosition = buttonTop.transform.position;
        location = (isLocked) ? _pressedInLocation : defaultPosition;
        buttonTop.transform.position = location;
	}
	
	// Update is called once per frame
	void Update () {
        if (inTrigger && Input.GetKeyDown(KeyCode.E)) //Allows player to toggle switch on and off
        {
            Debug.Log("Pressed Key");
            toggleObject.SendMessage("ToggleLocked");
            lockUnlock();
        }

        if (isMoving)
        {
            //Vector3 position = buttonTop.transform.position;
            //Vector3 movement = Vector3.MoveTowards(position, location, 1f);
            //buttonTop.transform.position = position;
            Vector3 movement = Vector3.MoveTowards(buttonTop.transform.position, location, .02f);
            buttonTop.transform.position = movement;
            if (Vector3.Equals(buttonTop.transform.position, location))
            {
                isMoving = false;
            }
        }
	}

    void lockUnlock()
    {
        isLocked = !isLocked;
        location = (isLocked) ? _pressedInLocation : defaultPosition;
        isMoving = true;
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
