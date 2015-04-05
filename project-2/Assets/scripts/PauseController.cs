using UnityEngine;
using System.Collections;

public class PauseController : MonoBehaviour {
    bool isPaused;
    public Canvas pauseMenu;

	// Use this for initialization
	void Start () {
        pauseMenu = GameObject.FindGameObjectWithTag("pauseCanvas").GetComponent<Canvas>();
        isPaused = false;
        pauseMenu.enabled = isPaused;
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            pauseMenu.enabled = isPaused;
            Time.timeScale = isPaused ? 0 : 1;
        }
	}

    public void RestartLevel()
    {
        Debug.Log("restarting level");
        Time.timeScale = 1;
        isPaused = false;
        Application.LoadLevel(Application.loadedLevelName);
    }

    public void loadNextLevel()
    {
        Time.timeScale = 1;
        Application.LoadLevel((int.Parse(Application.loadedLevelName.ToString()) + 1).ToString());
        Debug.Log("loaded level: " + (int.Parse(Application.loadedLevelName.ToString()) + 1).ToString());
        Timer timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
        timer.reset();
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        isPaused = false;
        Application.LoadLevel("Menu");
    }
}
