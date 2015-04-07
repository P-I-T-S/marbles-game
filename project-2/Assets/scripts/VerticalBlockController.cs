using UnityEngine;
using System.Collections;

/**
* Author: Duncan Dufva
**/

public class VerticalBlockController : MonoBehaviour {

    public int direction = -1;

    public string axis;

    public float MAX_MOVEMENT = 5;

    public float speed = 1;

    public const float directionalDelay = 1f;

    private float timer = directionalDelay;

    private bool waiting = false;

    public bool isLocked;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocked) //Can only move when not locked
        {
            if (waiting) //Stops the block once it hits a boundary
            {
                timer -= Time.deltaTime;
            }
            if (!waiting) //The part that does actual movement
            {
                float distance = direction * MAX_MOVEMENT * speed * Time.deltaTime;
                Vector3 position = transform.position;
                switch (axis)
                {
                    case "x":
                        position.x += distance;
                        break;
                    case "y":
                        position.y += distance;
                        break;
                    case "z":
                        position.z += distance;
                        break;
                }
                transform.position = position;
            }

            if (timer <= 0) //Resets timer and allows block to move
            {
                timer = directionalDelay;
                waiting = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit stopping block");
        if (!isLocked)
        {
            if (other.tag == "BlockStop")
            {
                waiting = true;

                direction *= -1;
            }
        }
        
    }

    public void ToggleUnlock()
    {
        isLocked = !isLocked;
    }
}