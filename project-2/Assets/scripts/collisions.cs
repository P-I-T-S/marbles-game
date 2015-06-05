using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class collisions : MonoBehaviour {
    public Text superJumpText;
    public Text superSpeedText;
    GameObject[] superJumps;
	GameObject[] superSpeeds;
    float superJumpForce = 800f;
	float superSpeedForce = 5000f;
	SphereCollider sphereCollider;
    bool canSuperJump;
	bool canSuperSpeed;
	bool hitSuperJump;
	bool hitSuperSpeed;
	Transform maincamera;
    Text gemsCollectedText;
    int numberOfGemsCollected;
    int totalNumberOfGems;

    // Initialization
    void Awake()
    {
		sphereCollider = this.gameObject.GetComponent<SphereCollider>();
        superJumps = GameObject.FindGameObjectsWithTag("Spring");
		superSpeeds = GameObject.FindGameObjectsWithTag ("SuperSpeed");
		maincamera = Camera.main.transform;
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
            ShowSuperJumpText();
            HideSuperSpeedText();
            canSuperJump = true;
            canSuperSpeed = false;
            col.gameObject.SetActive(false);
			hitSuperJump = true;
            Invoke("Display", 10);
        }
		//Super Speed
		else if (col.gameObject.tag == "SuperSpeed") {
            ShowSuperSpeedText();
            HideSuperJumpText();
			canSuperSpeed = true;
            canSuperJump = false;
			col.gameObject.SetActive(false);
			hitSuperSpeed = true;
			Invoke("Display", 10);
		}

        //Turning off powerups when level finished
        else if (col.gameObject.tag == "Finish")
        {
            HideSuperJumpText();
            HideSuperSpeedText();
            canSuperJump = false;
            canSuperSpeed = false;
        }

        // Gem pickup
//        else if(col.gameObject.tag == "Gem")
//        {
//            GameObject.Destroy(col.gameObject);
//        }
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
                HideSuperJumpText();
            }
        }
		//super speed
		if (canSuperSpeed) {
			if(Input.GetKeyDown(KeyCode.Mouse0)){
				decreaseFriction();
				float zInput = Input.GetAxis ("Vertical");
				Vector3 inputDir = new Vector3 (0, 0, zInput);
				Vector3 forwardDirection = maincamera.transform.TransformDirection (Vector3.forward);
				forwardDirection.y = 0;
				Rigidbody ballRigidBody = GetComponent<Rigidbody>();
				ballRigidBody.AddForce (forwardDirection * superSpeedForce);
				canSuperSpeed = false;
                HideSuperSpeedText();
			}
		}
    } // End of update method

	//Changing the friction for the superspeed 
	void decreaseFriction(){
		//turn off sound
//		GetComponent<AudioSource> ().enabled = false;
		//decrease friction
		sphereCollider.material.staticFriction = 10;
		sphereCollider.material.dynamicFriction = 10;
		Invoke ("increaseFriction", 1f);
	}
	void increaseFriction(){
		//turn on audio
//		GetComponent<AudioSource> ().enabled = true;
		sphereCollider.material.staticFriction = 9999999;
		sphereCollider.material.dynamicFriction = 1435.87f;
	}
	
    void Display()
    {
		if (hitSuperJump) {
            foreach (GameObject superJump in superJumps)
            {
                superJump.SetActive(true);
            }
			hitSuperJump = false;
		}
		if (hitSuperSpeed) {
            foreach (GameObject superSpeed in superSpeeds)
            {
                superSpeed.SetActive(true);
            }
			hitSuperSpeed = false;
		}

    } 


    void ShowSuperJumpText()
    {
        superJumpText.GetComponent<CanvasGroup>().alpha = 1;
    }

    void HideSuperJumpText()
    {
        superJumpText.GetComponent<CanvasGroup>().alpha = 0;
    }

    void ShowSuperSpeedText()
    {
        superSpeedText.GetComponent<CanvasGroup>().alpha = 1;
    }

    void HideSuperSpeedText()
    {
        superSpeedText.GetComponent<CanvasGroup>().alpha = 0;
    }

    void UpdateNumberOfGemsCollected()
    {
        this.numberOfGemsCollected = this.totalNumberOfGems - GameObject.FindGameObjectsWithTag("Gem").Length;
    }
}
