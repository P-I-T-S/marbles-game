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
        Timer.reset();
    }

    public void loadNextLevel()
    {
        Time.timeScale = 1;
        int nextLevel = int.Parse (Application.loadedLevelName.ToString()) + 1;
        if (nextLevel <= 9)
        {
			Application.LoadLevel(nextLevel.ToString()); //Load until last level
        }
        else
        {
        	Application.LoadLevel ("Menu"); //Load menu if last level has been completed
        }
        Debug.Log("loaded level: " + (int.Parse(Application.loadedLevelName.ToString()) + 1).ToString());
        Timer timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
        Timer.reset();
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        isPaused = false;
        Application.LoadLevel("Menu");
    }
}
