using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class gameManager : MonoBehaviour {

    // The names of the levels to load from the saved highscore data
    public string[] registeredLevelNames = {"1", "2", "3", "4", "5"};
    // A dictionary with the level name as the key and the list of players as the values
    public Dictionary<string, Player[]> highscores = new Dictionary<string, Player[]>();

    public List<Material> ballMaterials;
    public int selectedMaterial;


    void Awake()
    {
        //Default value if no material is selected
        selectedMaterial = -1;
        //PlayerPrefs.DeleteAll();
        // Makes sure the Game Manager persists while the game is running
        GameObject gameManager = GameObject.FindGameObjectWithTag("Game Manager");
        DontDestroyOnLoad(gameManager);
        // Load the highscores

        foreach(string levelName in registeredLevelNames)
        {
            // If this is the first time the game has been played, load filler data
            if (PlayerPrefs.GetString(levelName) == "")
            {
                PlayerPrefs.SetString(levelName, "Zoidberg:9999.0,Zoidberg:9999.0,Zoidberg:9999.0");
                PlayerPrefs.Save();
            }
                
            string highscoreData = PlayerPrefs.GetString(levelName);
            highscores.Add(levelName, parsePlayerData(highscoreData));
        }
    }
    /// <summary>
    /// Adds a score to the highscore if it is one of the top three.
    /// </summary>
    /// <param name="playerName">The name of the player</param>
    /// <param name="score">The time to store for the player</param>
    /// <returns>Return the tier you have taken(ex "bronze", "silver")</returns>
    public String addScore(int level, string playerName, float score)
    {
        if (!this.highscores.ContainsKey(level.ToString()))
        {
            return "error adding score";
        }
        else
        {
            String tier = "no tier";
            Player newScore = new Player(playerName, score);
            Player[] players = this.highscores[level.ToString()];
            Player[] temp = new Player[4];
            for(int i = players.Length - 1; i >= 0; i--)
            {
                // Check to see if a new tier was achieved
                if(newScore.CompareTo(players[i]) == -1)
                {
                    if(i == 2)
                        tier = "bronze";
                    else if(i == 1)
                        tier = "silver";
                    else
                        tier = "gold";

                }
                temp[i] = players[i];
            }

            // Add the new score and resort the array by scores (time)
            temp[3] = newScore;
            Debug.Log(players[0].Name);
            Array.Sort(temp);

            String playerPrefString = "";
            // Add the highscores back, removing the lowest one
            for (int i = 0; i < players.Length; i++)
            {
                players[i] = temp[i];
                if(players[i] != null)
                    Debug.Log(players[i].Time);
                playerPrefString += players[i].Name + ":" + players[i].Time.ToString();
                if (i != players.Length - 1)
                    playerPrefString += ",";
            }
               

            PlayerPrefs.SetString(level.ToString(), playerPrefString);
            PlayerPrefs.Save();
            return tier;
        }

    }
    private Player[] parsePlayerData(string data)
    {
        // There are always 3 highscores per level
        Player [] players = new Player [3];
        Debug.Log(data);
        // Split the string into players
        string[] playersString = data.Split(',');
        
        // Test if the string array is the right length
        if(playersString.Length == 3)
        {
            int count = 0;
            // Create players for each player in string
            foreach(string player in playersString)
            {
                string[] playerValues = player.Split(':');
                Debug.Log(playerValues.Length);
                Player p = new Player(playerValues[0], float.Parse(playerValues[1]));
                players[count] = p;
                count ++;
            }
        }
        else
        {
            Debug.Log("There was an error parsing player data: There was not exactly 3 highscores");
        }

        return players;
    }

    



}
