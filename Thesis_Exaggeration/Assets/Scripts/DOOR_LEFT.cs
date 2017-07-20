using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOOR_LEFT : MonoBehaviour {

	public float animSpeed = 1f;
	public Animation anim;

	void OnTriggerEnter(Collider other) {

		if(other.GetComponent<Collider>().tag == "Player")
		{
			GetComponent<Animation>().Play("left_door_open");
			anim["left_door_open"].speed = animSpeed;
		}

	}
}