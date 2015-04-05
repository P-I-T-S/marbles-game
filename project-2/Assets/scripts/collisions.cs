using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class collisions : MonoBehaviour {
    GameObject superJump;
	GameObject superSpeed;
    float superJumpForce = 800f;
	float superSpeedForce = 2000f;
    bool canSuperJump;
	bool canSuperSpeed;
	bool hitSuperJump;
	bool hitSuperSpeed;
    Text gemsCollectedText;
    int numberOfGemsCollected;
    int totalNumberOfGems;

    // Initialization
    void Awake()
    {
        superJump = GameObject.FindGameObjectWithTag("Spring");
		superSpeed = GameObject.FindGameObjectWithTag ("SuperSpeed");
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
			hitSuperJump = true;
            Invoke("Display", 20);
        }
		//Super Speed
		if (col.gameObject.tag == "SuperSpeed") {
			canSuperSpeed = true;
			col.gameObject.SetActive(false);
			hitSuperSpeed = true;
			Invoke("Display", 20);
		}

        // Gem pickup
        else if(col.gameObject.tag == "Gem")
        {
            GameObject.Destroy(col.gameObject);
        }
    }


    // Update GUI elements
    void OnGUI()
    {
        // Update number of gems collected
        UpdateNumberOfGemsCollected();
        gemsCollectedText.text = numberOfGemsCollected.ToString() + "/" + totalNumberOfGems.ToString();
    }

    void Update()
    {
		//super jump
        if (canSuperJump)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Vector3 jump = new Vector3(0, superJumpForce, 0);
                GetComponent<Rigidbody>().AddForce(jump);
                canSuperJump = false;
            }
        }
		//super speed
		if (canSuperSpeed) {
			if(Input.GetKeyDown(KeyCode.Mouse0)){
				Vector3 speed = new Vector3(0, 0, superSpeedForce);
				GetComponent<Rigidbody>().AddForce(speed);
				canSuperSpeed = false;
			}
		}
    }

    void Display()
    {
		if (hitSuperJump) {
			superJump.SetActive (true);
			hitSuperJump = false;
		}
		if (hitSuperJump) {
			superSpeed.SetActive (true);
			hitSuperSpeed = false;
		}

    }

    void UpdateNumberOfGemsCollected()
    {
        this.numberOfGemsCollected = this.totalNumberOfGems - GameObject.FindGameObjectsWithTag("Gem").Length;
    }
}
