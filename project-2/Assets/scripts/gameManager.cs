using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class gameManager : MonoBehaviour {

    // The names of the levels to load from the saved highscore data
    string[] registeredLevelNames = { "Level_1", "Level_2" };
    // A dictionary with the level name as the key and the list of players as the values
    Dictionary<string, Player[]> highscores = new Dictionary<string, Player[]>();

    void Awake()
    {
        // Makes sure the Game Manager persists while the game is running
        GameObject gameManager = GameObject.FindGameObjectWithTag("Game Manager");
        DontDestroyOnLoad(gameManager);

        // Load the highscores
        foreach(string levelName in registeredLevelNames)
        {
            // If this is the first time the game has been played, load filler data
            if (PlayerPrefs.GetString(levelName) == "")
            {
                PlayerPrefs.SetString(levelName, "Lawrence:0.0 Lawrence:0.0 Lawrence:0.0");
                PlayerPrefs.Save();
            }
            else
            {
                string highscoreData = PlayerPrefs.GetString(levelName);
                highscores.Add(levelName, parsePlayerData(highscoreData));
            }
        }
    }

    private Player[] parsePlayerData(string data)
    {
        // There are always 3 highscores per level
        Player [] players = new Player [3];
        // Split the string into players
        string[] playersString = data.Split(' ');
        
        // Test if the string array is the right length
        if(playersString.Length == 3)
        {
            int count = 0;
            // Create players for each player in string
            foreach(string player in playersString)
            {
                string[] playerValues = player.Split(':');
                Player p = new Player(playerValues[0], float.Parse(playerValues[1]));
                players[count] = p;
                count ++;
            }
        }
        else
        {
            Debug.Log("There was an error parsing player data: There was not exactly 5 highscores");
        }

        return players;
    }

}
