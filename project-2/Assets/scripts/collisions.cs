using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class collisions : MonoBehaviour {
    GameObject superJump;
    float superJumpForce = 800f;
    bool canSuperJump;
    Text gemsCollectedText;
    int numberOfGemsCollected;
    int totalNumberOfGems;

    // Initialization
    void Awake()
    {
        superJump = GameObject.FindGameObjectWithTag("Spring");
        GameObject gemsCollectedUI = GameObject.FindGameObjectWithTag("gemsCollectedGuiText");
        gemsCollectedText = gemsCollectedUI.GetComponent<Text>();
        numberOfGemsCollected = 0;
        totalNumberOfGems = GameObject.FindGameObjectsWithTag("Gem").Length;
    }

    void Start()
    {

    }

    // Collision events
    void OnTriggerEnter(Collider col)
    {
        // Super Jump pickup
        if (col.gameObject.tag == "Spring")
        {
            canSuperJump = true;
            col.gameObject.SetActive(false);
            Invoke("Display", 20);
        }
        // Gem pickup
        else if(col.gameObject.tag == "Gem")
        {
            GameObject.Destroy(col.gameObject);
            Debug.Log("Gem collected!");
            numberOfGemsCollected++;
        }
    }

    // Update GUI elements
    void OnGUI()
    {
        // Update number of gems collected
        gemsCollectedText.text = numberOfGemsCollected.ToString() + "/" + totalNumberOfGems.ToString();
    }

    void Update()
    {
        if (canSuperJump)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Vector3 jump = new Vector3(0, superJumpForce, 0);
                GetComponent<Rigidbody>().AddForce(jump);
                canSuperJump = false;
            }
        }
    }

    void Display()
    {
        superJump.SetActive(true);
    }
}
