using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rigidbody_off : MonoBehaviour {

    private Rigidbody rBody; //or public Rigidbody rBody;

    void Start()
    {
       // rBody.detectCollisions = false;// this will not affect the graphics
                                       // of an object but will make other rigidbodies pass through itt without 
                                       //triggering a collision

        rBody.GetComponent<SphereCollider>().enabled = false;
    }
    void Update() //or in any function
    {
        if (Input.GetKeyDown("space"))
        {
           // rBody = GetComponent<Rigidbody>();
            rBody.GetComponent<SphereCollider>().enabled = true;
        }

    }
}
