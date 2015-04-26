using UnityEngine;
using System.Collections;

public class MarbleMaterialLoaderButton : MonoBehaviour {

    public int materialIndex;
    public GameObject materialSwitcher;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadMaterial()
    {
        materialSwitcher.GetComponent<MainMenuMaterialSwitcher>().SwitchMaterial(materialIndex);
    }
}
