using UnityEngine;
using System.Collections;

public class LevelListLoader : MonoBehaviour {

    public string levelName;
    public GameObject levelLoader;
	// Use this for initialization
	public void OnClick()
    {
        Debug.Log(levelName);
        levelLoader.GetComponent<LevelLoader>().levelName = this.levelName;
    }
}
