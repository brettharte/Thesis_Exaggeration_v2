using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addtorque : MonoBehaviour
{
    public Rigidbody wall;

    void Update()
    {
        //if (Input.GetKeyDown ("space")); 
        wall.GetComponent<Rigidbody>();
        //StartCoroutine("waitTwoSeconds");

        //-- if (gameObject.tag == "cube")
        //--{DestroyObject(gameObject);
        //-- }
    }

    void FixedUpdate()
    {
        wall.AddForce(Vector3.left * 5f, ForceMode.Force);
        wall.AddTorque(Vector3.left * 10000f, ForceMode.Force);
    }
}
