using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableHands : MonoBehaviour {

	void Start () {
        // setup switchable hands:
        GameObject.Find("LeftHandAnchor").GetComponent<switchHands>().enabled = true;
        GameObject.Find("RightHandAnchor").GetComponent<switchHands>().enabled = true;
    }

}
