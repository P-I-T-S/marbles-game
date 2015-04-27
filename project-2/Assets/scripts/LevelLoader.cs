using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {

    void Start()
    {
        gameManager gameMan = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<gameManager>();
        InputField inputField = GameObject.Find("playerNameInput").GetComponent<InputField>();
        GameObject input = GameObject.FindGameObjectWithTag("playerNameInputText");

        if (gameMan.playerName != "")
        {
            inputField.placeholder.GetComponent<Text>().text = gameMan.playerName;
            inputField.interactable = false;
        }
        else
        {
            input.GetComponent<Text>().text = "";
            inputField.interactable = true;
        }

    }
    public string levelName;

    public void LoadLevel()
    {
        if (levelName != null)
        {
            Application.LoadLevel(levelName);
        }
    }


}
