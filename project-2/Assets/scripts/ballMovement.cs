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


	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody> ();
		mainCamera = Camera.main.transform;
		rigidbody.maxAngularVelocity = 45;
		collider = GetComponentInChildren<BoxCollider> ();
		distToGround = collider.bounds.extents.y;
        levelCompleteCanvas = GameObject.FindGameObjectWithTag("levelCompleteCanvas").GetComponent<Canvas>();
        levelCompleteCanvas.enabled = false;
	}
	bool IsGrounded() 
	{
		return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.2f);
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
		    Vector3 inputDir = new Vector3 (xInput * -1, 0, zInput);

		    // Get direction the camera is faceing, transforming it to global vectors
		    Vector3 forwardDirection = mainCamera.transform.TransformDirection (Vector3.forward);
		    Vector3 righDirection = mainCamera.transform.TransformDirection (Vector3.right);

		    // Set the direction to move base on the direction the camera is faceing and the user input
		    Vector3 moveDirection = (righDirection * inputDir.z) + (forwardDirection * inputDir.x);
		    // Remove the vertical component
		    moveDirection.y = 0;
		    // Normonlize the vector so all magnitudes are the same
		    moveDirection.Normalize ();

		    // Move the ball, multiplying by the speed value
		    //rigidbody.AddForce (moveDirection * speed);
		    rigidbody.AddTorque(moveDirection * speed);
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
            // If the player falls off, reload the level
            Application.LoadLevel(Application.loadedLevelName);
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
                Debug.Log("Level complete!");
                LevelCompletion();
            }
            else
            {
                Debug.Log("Not all gems have been collected!");
            }

        }
    }

    void LevelCompletion()
    {
        Time.timeScale = 0;
        levelCompleteCanvas.enabled = true;
    }

}
