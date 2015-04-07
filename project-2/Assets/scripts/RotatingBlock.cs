using UnityEngine;
using System.Collections;

public class RotatingBlock : MonoBehaviour {

    public string axis;
    public int direction;
    public float rotationsPerSecond;
    private const float COMPLETE_ROTATION = 360;
    private float rotateValue;
    public bool locked;
	// Use this for initialization
	void Start () {
        rotateValue = rotationsPerSecond * COMPLETE_ROTATION;
	}
	
	// Update is called once per frame
    void Update()
    {
        if (!locked)
        {
            float rotation = rotateValue * Time.deltaTime * (float)direction;
            switch (axis)
            {
                case "x":
                    transform.Rotate(new Vector3(rotation, 0, 0));
                    break;
                case "y":
                    transform.Rotate(new Vector3(0, rotation, 0));
                    break;
                case "z":
                    transform.Rotate(new Vector3(0, 0, rotation));
                    break;
            }
        }
    }

    void ToggleLocked()
    {
        locked = !locked;
    }
}
