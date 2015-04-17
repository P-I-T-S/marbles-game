using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class collisions : MonoBehaviour {
    public Text superJumpText;
    GameObject superJump;
	GameObject superSpeed;
    float superJumpForce = 800f;
	float superSpeedForce = 5000f;
	SphereCollider sphereCollider;
    bool canSuperJump;
	bool canSuperSpeed;
	bool hitSuperJump;
	bool hitSuperSpeed;
	bool frictionChanged; 
	float startTime;
	float time;
	Transform maincamera;
    Text gemsCollectedText;
    int numberOfGemsCollected;
    int totalNumberOfGems;

    // Initialization
    void Awake()
    {
		sphereCollider = this.gameObject.GetComponent<SphereCollider>();
        superJump = GameObject.FindGameObjectWithTag("Spring");
		superSpeed = GameObject.FindGameObjectWithTag ("SuperSpeed");
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
            Show();
            canSuperJump = true;
            canSuperSpeed = false;
            col.gameObject.SetActive(false);
			hitSuperJump = true;
            Invoke("Display", 10);
        }
		//Super Speed
		else if (col.gameObject.tag == "SuperSpeed") {
			canSuperSpeed = true;
            canSuperJump = false;
			col.gameObject.SetActive(false);
			hitSuperSpeed = true;
			Invoke("Display", 10);
		}

        //Turning off powerups when level finished
        else if (col.gameObject.tag == "Finish")
        {
            Hide();
            canSuperJump = false;
            canSuperSpeed = false;
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
                Hide();
            }
        }
		//super speed
		if (canSuperSpeed) {
			if(Input.GetKeyDown(KeyCode.Mouse0)){
				frictionChanged = true;
				if(frictionChanged){
					changeFriction();
				}
				float zInput = Input.GetAxis ("Vertical");
				Vector3 inputDir = new Vector3 (0, 0, zInput);
				Vector3 forwardDirection = maincamera.transform.TransformDirection (Vector3.forward);
				forwardDirection.y = 0;
				Rigidbody ballRigidBody = GetComponent<Rigidbody>();
				ballRigidBody.AddForce (forwardDirection * superSpeedForce);
				canSuperSpeed = false;
			}
		}
    }
	//Changing the friction for the superspeed 
	void changeFriction(){
		Debug.Log (sphereCollider.material.dynamicFriction);
		startTime = Time.deltaTime;
		Debug.Log (startTime);
		time = Time.deltaTime;
		Debug.Log (time);
		sphereCollider.material.staticFriction = 10;
		sphereCollider.material.dynamicFriction = 10;
		sphereCollider.material.staticFriction2 = 10;
		sphereCollider.material.dynamicFriction2 = 10;
		Debug.Log (sphereCollider.material.dynamicFriction);
		Debug.Log ("SCREW FRICTION!!!");
		if (time - startTime >= 2) {
			Debug.Log (startTime);
			Debug.Log (time);
			Debug.Log("FRICTION!!!!");
			sphereCollider.material.staticFriction = 9999999;
			sphereCollider.material.dynamicFriction = 1435.87f;
			frictionChanged = false;
		}

	}
	
    void Display()
    {
		if (hitSuperJump) {
			superJump.SetActive (true);
			hitSuperJump = false;
		}
		if (hitSuperSpeed) {
			superSpeed.SetActive (true);
			hitSuperSpeed = false;
		}

    }

    void Show()
    {
        superJumpText.GetComponent<CanvasGroup>().alpha = 1;
    }

    void Hide()
    {
        superJumpText.GetComponent<CanvasGroup>().alpha = 0;
    }

    void UpdateNumberOfGemsCollected()
    {
        this.numberOfGemsCollected = this.totalNumberOfGems - GameObject.FindGameObjectsWithTag("Gem").Length;
    }
}
