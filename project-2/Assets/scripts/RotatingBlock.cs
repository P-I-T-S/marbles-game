using UnityEngine;
using System.Collections;

public class RotatingBlock : MonoBehaviour {

    public string axis;
    public double timeToCompleteRotation;
    private const double COMPLETE_ROTATION = 360;
    private double rotateValue;
	// Use this for initialization
	void Start () {
        rotateValue = timeToCompleteRotation * COMPLETE_ROTATION;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
