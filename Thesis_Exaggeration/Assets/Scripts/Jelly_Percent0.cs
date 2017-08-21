using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly_Percent0 : MonoBehaviour {

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "player")
        {
            Application.LoadLevel("softbody_O");
        }
    }
}
