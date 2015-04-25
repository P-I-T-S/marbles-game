using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class infoAndTipsScript : MonoBehaviour {
    Canvas infoAndTipsCanvas;
    Text infoAndTipsText;
    int levelName;
    GameObject timer;
    string[] listOfTips = { "level 0, do not use", "Use the w, a, s and d keys to move to the green platform", "Collect the gems, then go the the finish platform"};

	// Use this for initialization
	void Start () {
        infoAndTipsCanvas = this.GetComponent<Canvas>();
        infoAndTipsText = GameObject.FindGameObjectWithTag("infoAndTipsText").GetComponent<Text>();
        
        levelName = int.Parse(Application.loadedLevelName);
        infoAndTipsText.text = listOfTips[levelName];
        infoAndTipsCanvas.enabled = false;

        Invoke("ShowInfoAndTips", 1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void ShowInfoAndTips()
    {
        infoAndTipsCanvas.enabled = true;
        Invoke("HideInfoAndTips", 15);
        
    }
    void HideInfoAndTips()
    {
        infoAndTipsCanvas.enabled = false;
    }
}
