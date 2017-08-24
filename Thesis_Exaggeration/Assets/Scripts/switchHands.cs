using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchHands : MonoBehaviour {
    private GameObject fist;
    private GameObject openhand;
    private GameObject pointinghand;
    private OVRInput.Button indexfingerbutton = OVRInput.Button.PrimaryIndexTrigger;
    private OVRInput.Button handbutton = OVRInput.Button.PrimaryHandTrigger;
	
	void Start () {
        fist = this.transform.Find("fist").gameObject;
        openhand = this.transform.Find("openhand").gameObject;
        pointinghand = this.transform.Find("pointinghand").gameObject;
        foreach (Transform child in transform) {
            child.gameObject.SetActive(false);
        }
        if (this.name.ToLower().Contains("right"))
        {
            indexfingerbutton = OVRInput.Button.SecondaryIndexTrigger;
            handbutton = OVRInput.Button.SecondaryHandTrigger;
        }
        else if (this.name.ToLower().Contains("left"))
        {
            indexfingerbutton = OVRInput.Button.PrimaryIndexTrigger;
            handbutton = OVRInput.Button.PrimaryHandTrigger;
        }
        else
        {
            Debug.LogWarning("This script needs to be on a gameobject with left or right in the name!");
        }
    }
	

	void Update () {
        if (OVRInput.Get(handbutton))
        {
            if (OVRInput.Get(indexfingerbutton))
            {
                openhand.SetActive(false);
                fist.SetActive(true);
                pointinghand.SetActive(false);
            }
            else
            {
                openhand.SetActive(false);
                fist.SetActive(false);
                pointinghand.SetActive(true);
            }
        }
        else
        {
            openhand.SetActive(true);
            fist.SetActive(false);
            pointinghand.SetActive(false);
        }
	}
}
