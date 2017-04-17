using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOOR_RIGHT : MonoBehaviour {



	void OnTriggerEnter(Collider other) {

		if(other.GetComponent<Collider>().tag == "Player")
		{
			GetComponent<Animation>().Play("door_close_RIGHT");
		}

	}
}