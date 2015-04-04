using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour {

    public string levelName;

    public void LoadLevel()
    {
        if (levelName != null)
        {
            Application.LoadLevel(levelName);
        }
    }


}
