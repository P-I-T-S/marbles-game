﻿using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
    public static float time { get; set; }
    private Rect currentRect = new Rect(15, 15, 150, 150);
    public GUIStyle style;
	// Use this for initialization
	void Start () {
        
	}
    void OnGUI()
    {
        currentRect.x = (Screen.width * .5f) - (currentRect.width * 0.5f);
        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time - minutes * 60);
        int milliseconds = (int)((time - Mathf.Floor(time)) * 1000);

        string Time = string.Format("{0:0}:{1:00}:{2:000}", minutes, seconds, milliseconds);
        GUI.Label(new Rect(currentRect.x, 0, 200, 50), Time, style);
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
	}

    public static void reset()
    {
        time = 0.0f;
    }

    public static string ToString()
    {
        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time - minutes * 60);
        int milliseconds = (int)((time - Mathf.Floor(time)) * 1000);

        return string.Format("{0:0}:{1:00}:{2:000}", minutes, seconds, milliseconds);
       
    }
}
