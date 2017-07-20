using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freeze_all : MonoBehaviour {

    void Start()
    {
        var rb = GetComponent<Rigidbody>();
        //Modify the constraints directly.
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }
}
