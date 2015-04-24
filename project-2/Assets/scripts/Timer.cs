using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
    public static float timer;
    private Rect currentRect = new Rect(15, 15, 150, 150);
    public GUIStyle style;
	// Use this for initialization
	void Start () {
        
	}
    void OnGUI()
    {
        currentRect.x = (Screen.width * .5f) - (currentRect.width * 0.5f);
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        int milliseconds = (int)((timer - Mathf.Floor(timer)) * 1000);

        string Time = string.Format("{0:0}:{1:00}:{2:000}", minutes, seconds, milliseconds);
        GUI.Label(new Rect(currentRect.x, 0, 250, 250), Time, style);
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
	}

    public void reset()
    {
        timer = 0.0f;
    }
}
