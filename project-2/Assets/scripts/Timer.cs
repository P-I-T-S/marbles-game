using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
    public static float timer;
	// Use this for initialization
	void Start () {
        
	}
    void OnGUI()
    {
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);

        string Time = string.Format("{0:0}:{1:00}", minutes, seconds);
        GUI.skin.label.fontSize = 50;
        GUI.color = Color.black;
        GUI.Label(new Rect(475, 0, 250, 250), Time);
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
	}
}
