﻿using UnityEngine;
using System.Collections;

public class rotateItem : MonoBehaviour {
    public int rotateSpeed = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.back, rotateSpeed * Time.deltaTime);
	}
}
