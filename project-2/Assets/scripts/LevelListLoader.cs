using UnityEngine;
using System.Collections;

public class LevelListLoader : MonoBehaviour {

    public string levelName;
    public GameObject levelLoader;
    public GameObject gameManager;
    public UnityEngine.UI.Text highScoreDisplay;
	// Use this for initialization
	public void OnClick()
    {
        levelLoader.GetComponent<LevelLoader>().levelName = this.levelName;

        string[] levelNames = gameManager.GetComponent<gameManager>().registeredLevelNames;

        bool validLevel = false;
        foreach (string level in levelNames)
        {
            if (level.Equals(levelName))
            {
                validLevel = true;
                break;
            }
        }
        if (validLevel)
        {
            Player[] scores = gameManager.GetComponent<gameManager>().highscores[levelName];
            string highScores = "";
            foreach (Player player in scores)
            {
                highScores += player.Name + " - " + player.Time + "\n";
            }

            highScoreDisplay.text = highScores;
        }
    }
}
