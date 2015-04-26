using UnityEngine;
using System.Collections;

public class MaterialLoader : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject gameManager = GameObject.FindGameObjectWithTag("Game Manager");
        if (gameManager != null)
        {
            if (gameManager.GetComponent<gameManager>().selectedMaterial >= 0)
            {
                GetComponent<MeshRenderer>().material =
                    gameManager.GetComponent<gameManager>()
                    .ballMaterials[gameManager.GetComponent<gameManager>().selectedMaterial];
            }
        }
	}
}
