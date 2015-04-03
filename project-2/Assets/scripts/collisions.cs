using UnityEngine;
using System.Collections;

public class collisions : MonoBehaviour {
    GameObject superJump;
    float superJumpForce;
    int numSuperJump;
    void Start()
    {
        superJump = GameObject.FindGameObjectWithTag("Spring");
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Spring")
        {
            superJumpForce = 800f;
            numSuperJump = 1;
            if (numSuperJump == 1)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Vector3 jump = new Vector3(0, superJumpForce, 0);
                    GetComponent<Rigidbody>().AddForce(jump);
                    numSuperJump = 0;
                }
            }
            col.gameObject.SetActive(false);
            Invoke("Display", 5);
        }
    }

    void Display()
    {
        superJump.SetActive(true);
    }
}
