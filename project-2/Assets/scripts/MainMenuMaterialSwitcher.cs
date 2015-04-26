using UnityEngine;
using System.Collections;

public class MainMenuMaterialSwitcher : MonoBehaviour {

    public GameObject marble;
    public GameObject gameManager;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SwitchMaterial(int i)
    {
        marble.GetComponent<MeshRenderer>().material = gameManager.GetComponent<gameManager>().ballMaterials[i];
        gameManager.GetComponent<gameManager>().selectedMaterial = i;
    }
}
