using UnityEngine;
using System.Collections;

public class PauseController : MonoBehaviour {
    bool isPaused, buttonDown;
    public Canvas pauseMenu;

	// Use this for initialization
	void Start () {
        isPaused = false;
        pauseMenu.enabled = isPaused;
        buttonDown = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Escape) && !buttonDown)
        {
            isPaused = !isPaused;
            pauseMenu.enabled = isPaused;
            buttonDown = true;
            Time.timeScale = isPaused ? 0 : 1;
        }
        else if (buttonDown)
        {
            buttonDown = false;
        }
	}

    public void RestartLevel()
    {
        Time.timeScale = 1;
        isPaused = false;
        Application.LoadLevel(Application.loadedLevelName);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        isPaused = false;
        //Application.LoadLevel("MainMenuSceneName");
    }
}
