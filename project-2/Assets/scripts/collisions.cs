using UnityEngine;
using System.Collections;

public class collisions : MonoBehaviour {
    GameObject superJump;
    float superJumpForce = 800f;
    bool canSuperJump;
    void Start()
    {
        superJump = GameObject.FindGameObjectWithTag("Spring");
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Spring")
        {
            canSuperJump = true;
            col.gameObject.SetActive(false);
            Invoke("Display", 20);
        }
        else if(col.gameObject.tag == "Gem")
        {
            GameObject.Destroy(col.gameObject);
            Debug.Log("Gem collected!");
            // Need to update GUI to show gem has been collected
        }
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
