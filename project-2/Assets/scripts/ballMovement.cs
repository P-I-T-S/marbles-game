using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ballMovement : MonoBehaviour {
	public float speed = 10f;
	Rigidbody rigidbody;
	float xInput;
	float zInput;
	private Transform mainCamera;
    private bool buttonDown;
	float distToGround;
	public float jumpForce = 250f;
	BoxCollider collider;
    public Canvas levelCompleteCanvas;
    Timer timer;
    Canvas gemsCollectedCanvas;
    Canvas infoAndTipsCanvas;
    Text levelCompleteTimeText;
    gameManager gameManager;
    RaycastHit hitInfo;

	// Use this for initialization
	void Start () {
		hitInfo = new RaycastHit();
		rigidbody = GetComponent<Rigidbody> ();
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
		mainCamera = Camera.main.transform;
		rigidbody.maxAngularVelocity = 45;
		collider = GetComponentInChildren<BoxCollider> ();
		distToGround = collider.bounds.extents.y;
        levelCompleteCanvas = GameObject.FindGameObjectWithTag("levelCompleteCanvas").GetComponent<Canvas>();
        gemsCollectedCanvas = GameObject.FindGameObjectWithTag(("gemsCollectedCanvas")).GetComponent<Canvas>();
        infoAndTipsCanvas = GameObject.FindGameObjectWithTag("infoAndTipsCanvas").GetComponent<Canvas>();
        levelCompleteTimeText = GameObject.FindGameObjectWithTag("levelCompleteTimeText").GetComponent<Text>();
        gameManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<gameManager>();
        levelCompleteCanvas.enabled = false;

	}
	public bool IsGrounded() 
	{
		return Physics.Raycast(transform.position, -Vector3.up, out hitInfo, distToGround + 0.2f, 1);
	}
	// Update is called once per frame
	void Update () {

        buttonDown = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);

        if (buttonDown)
        {
            // Get the user input
		    xInput = Input.GetAxis ("Horizontal");
		    zInput = Input.GetAxis ("Vertical");

		    // Move the ball, multiplying by the speed value
            if (IsGrounded())
            {
				
				if (hitInfo.collider.tag == "Rotate")
				{
					GetComponent<Transform>().SetParent(hitInfo.collider.gameObject.GetComponent<Transform>().parent);
				}
            
                Vector3 inputDir = new Vector3(xInput * -1, 0, zInput);

                // Get direction the camera is faceing, transforming it to global vectors
                Vector3 forwardDirection = mainCamera.transform.TransformDirection(Vector3.forward);
                Vector3 righDirection = mainCamera.transform.TransformDirection(Vector3.right);

                // Set the direction to move base on the direction the camera is faceing and the user input
                Vector3 moveDirection = (righDirection * inputDir.z) + (forwardDirection * inputDir.x);
                // Remove the vertical component
                moveDirection.y = 0;
                // Normonlize the vector so all magnitudes are the same
                moveDirection.Normalize();
                rigidbody.AddTorque(moveDirection * speed);
            }
            else
            {
                GetComponent<Transform>().SetParent(transform);
            	//GetComponent<Transform>().SetParent(thi);
                Vector3 inputDir = new Vector3(zInput, 0, xInput);

                // Get direction the camera is faceing, transforming it to global vectors
                Vector3 forwardDirection = mainCamera.transform.TransformDirection(Vector3.forward);
                Vector3 righDirection = mainCamera.transform.TransformDirection(Vector3.right);

                // Set the direction to move base on the direction the camera is faceing and the user input
                Vector3 moveDirection = (righDirection * inputDir.z) + (forwardDirection * inputDir.x);
                // Remove the vertical component
                moveDirection.y = 0;
                // Normonlize the vector so all magnitudes are the same
                moveDirection.Normalize();

                rigidbody.AddForce(moveDirection * speed / 4);
            }
        }
		

		// Causes the ball to jump into the air if space bar is pressed (only if ball is grounded)
		if (IsGrounded ()) {
			if (Input.GetKeyDown (KeyCode.Space)) {
                Vector3 jump = new Vector3(0, jumpForce, 0);
                GetComponentInParent<Rigidbody>().AddForce(jump);
               
			}
		}
		//Might need to change this to be position.y of both the start and finish platform
        if(transform.position.y < -20)
        {
            // If the player falls off, reload the level and reset the timer
            Application.LoadLevel(Application.loadedLevelName);
            Timer.reset();
        }
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Finish")
        {
            // Check if all gems are collected
            if(GameObject.FindGameObjectsWithTag("Gem").Length == 0)
            {
                // Found all gems
                LevelCompletion();
            }
            else
            {
                Invoke("DisplayNotAllGems", 0);
            }

        }
    }

    void LevelCompletion()
    {
        Time.timeScale = 0;
		GetComponent<AudioSource> ().enabled = false;
		GameObject.FindGameObjectWithTag("Finish").GetComponent<GemAudio> ().setLevelComplete();
        levelCompleteCanvas.enabled = true;
        timer.enabled = false;
        gemsCollectedCanvas.enabled = false;
        infoAndTipsCanvas.enabled = false;
        levelCompleteTimeText.text = "Time: " + Timer.ToString();

        Text newBestTimeTier = GameObject.Find("newBestTimeTier").GetComponent<Text>();
        
        string newHighScoreTier = gameManager.addScore(int.Parse(Application.loadedLevelName), gameManager.playerName, Timer.time);
        if (newHighScoreTier == "no tier")
        {
            GameObject[] newBestTimeObjects = GameObject.FindGameObjectsWithTag("newBestTime");
            foreach (GameObject o in newBestTimeObjects)
            {
                o.SetActive(false);
            }
        }
        else if(newHighScoreTier == "gold") {
            newBestTimeTier.text = "-Gold Tier Achived-";
        }
        else if (newHighScoreTier == "silver")
        {
            newBestTimeTier.text = "-Silver Tier Achived-";
        }
        else
        {
            newBestTimeTier.text = "-Bronze Tier Achived-";
        }

        
    }



    void DisplayNotAllGems()
    {
        infoAndTipsCanvas.GetComponentInChildren<Text>().text = "Not all gems have been collected!";
        Invoke("HideNotAllGems", 10);
    }
    void HideNotAllGems()
    {
        infoAndTipsCanvas.GetComponentInChildren<Text>().text = "";
    }

}
