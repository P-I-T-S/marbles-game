﻿using UnityEngine;
using System.Collections;

public class underwatermarble : MonoBehaviour {
    Rigidbody rb;
    public int underwaterlevel;
    public float drag;
    public float mass;
    public float speed;
    public float jumpForce;
    ballMovement movement;
    SphereCollider marbleCollider;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        movement = GetComponent<ballMovement>();
        marbleCollider = GetComponent<SphereCollider>();
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < underwaterlevel)
        {
            rb.drag = drag;
            rb.mass = mass;
            movement.speed = speed;
            movement.jumpForce = jumpForce;
            marbleCollider.material = (PhysicMaterial)Resources.Load("noBounce");
        }
        else
        {
            rb.drag = 0.5f;
            rb.mass = 1.2f;
            movement.speed = 12.5f;
            movement.jumpForce = 250f;
            marbleCollider.material = (PhysicMaterial)Resources.Load("bounce");
        }
	}
}
