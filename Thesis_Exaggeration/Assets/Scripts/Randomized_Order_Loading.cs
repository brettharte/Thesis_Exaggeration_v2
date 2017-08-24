using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomized_Order_Loading : MonoBehaviour {

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
           // yield WaitForSeconds(10); // wait 10 seconds
            Application.LoadLevel("softbody_O");
          
        }
    }
}
