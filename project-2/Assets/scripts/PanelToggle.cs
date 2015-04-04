using UnityEngine;
using System.Collections;

public class PanelToggle : MonoBehaviour {

    public GameObject panel1, panel2, offScreenPos;
    private Vector3 panel1Pos, panel2Pos;
	void Start () {
        panel1Pos = panel1.transform.position;
        panel2Pos = panel2.transform.position;
        if (panel2.transform.position.x != offScreenPos.transform.position.x)
            panel2.transform.position = offScreenPos.transform.position;
	}

    public void Toggle()
    {
        swapPos(panel1, panel1Pos);
        swapPos(panel2, panel2Pos);
    }

    private void swapPos(GameObject panel, Vector3 screenPos)
    {
        if (panel.transform.position.x != offScreenPos.transform.position.x)
        {
            panel.transform.position = offScreenPos.transform.position;
        }
        else
        {
            panel.transform.position = screenPos;
        }
    }
}
