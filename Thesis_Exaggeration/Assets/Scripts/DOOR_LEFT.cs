using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOOR_LEFT : MonoBehaviour {



	void OnTriggerEnter(Collider other) {

		if(other.GetComponent<Collider>().tag == "Player")
		{
			GetComponent<Animation>().Play("machine_door_left");
		}

	}
}