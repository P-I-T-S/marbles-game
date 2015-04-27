using UnityEngine;
using System.Collections;

public class PanelToggle : MonoBehaviour {

    public GameObject mainMenu, levelSelector, ballOptions, offScreenPos, marble;
    private Vector3 mainMenuPos, levelSelectorPos, ballOptionsPos;
    private bool mainMenuSwitch, levelSelectorSwitch, ballOptionsSwitch;
	void Start () {
        mainMenuSwitch = true;
        levelSelectorSwitch = true;
        ballOptionsSwitch = true;
        mainMenuPos = mainMenu.transform.position;
        levelSelectorPos = levelSelector.transform.position;
        ballOptionsPos = ballOptions.transform.position;
        marble.GetComponent<MeshRenderer>().enabled = false;


        swapPos(ballOptions, ballOptionsPos, ballOptionsSwitch);
        swapPos(levelSelector, levelSelectorPos, levelSelectorSwitch);
        levelSelectorSwitch = !levelSelectorSwitch;
        ballOptionsSwitch = !ballOptionsSwitch;
	}

    public void ToggleLevelSelector()
    {
        swapPos(mainMenu, mainMenuPos, mainMenuSwitch);
        swapPos(levelSelector, levelSelectorPos, levelSelectorSwitch);
        mainMenuSwitch = !mainMenuSwitch;
        levelSelectorSwitch = !levelSelectorSwitch;
    }

    public void ToggleBallCustomization()
    {
        swapPos(mainMenu, mainMenuPos, mainMenuSwitch);
        swapPos(ballOptions, ballOptionsPos, ballOptionsSwitch);
        marble.GetComponent<MeshRenderer>().enabled = !marble.GetComponent<MeshRenderer>().enabled;
        mainMenuSwitch = !mainMenuSwitch;
        ballOptionsSwitch = !ballOptionsSwitch;
    }

    private void swapPos(GameObject panel, Vector3 screenPos, bool panelSwitch)
    {
        if (!panelSwitch)
        {
            panel.transform.position = screenPos;
        }
        else
        {
            panel.transform.position = offScreenPos.transform.position;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
