using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch_Controller : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        transform.localPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
        transform.localPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);

    }
}
