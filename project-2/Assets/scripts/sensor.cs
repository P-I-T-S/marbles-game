using UnityEngine;
using System.Collections;

public class sensor : MonoBehaviour {
    public Transform toggleObject1;
    public Transform toggleObject2;
    public Transform toggleObject3;
    VerticalBlockController firstMovingBlock;
    VerticalBlockController secondMovingBlock;
    VerticalBlockController thirdMovingBlock;

	// Use this for initialization
	void Start () {
        firstMovingBlock = toggleObject1.GetComponent<VerticalBlockController>();
        secondMovingBlock = toggleObject2.GetComponent<VerticalBlockController>();
        thirdMovingBlock = toggleObject3.GetComponent<VerticalBlockController>();
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Top1")
        {
            firstMovingBlock.isLocked = false;
        }

        if (col.gameObject.name == "Top2")
        {
            secondMovingBlock.isLocked = false;
        }

        if (col.gameObject.name == "Top3")
        {
            thirdMovingBlock.isLocked = false;
        }

    }

	// Update is called once per frame
	void Update () {
	
	}
}
