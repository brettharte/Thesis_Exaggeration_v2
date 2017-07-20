using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideHands : MonoBehaviour {

    public GameObject lefthand;
    public GameObject righthand;

	// Use this for initialization
	void Start () {

     

        lefthand.SetActive(false);
        righthand.SetActive(false);

        StartCoroutine(showhands());



		
	}
	
	// Update is called once per frame
	IEnumerator showhands () {
        yield return new WaitForSeconds(5);
        lefthand.SetActive(true);
        righthand.SetActive(true);

    }
}
