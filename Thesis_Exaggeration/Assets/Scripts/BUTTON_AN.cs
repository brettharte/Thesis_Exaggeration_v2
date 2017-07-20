using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BUTTON_AN : MonoBehaviour {

	public float animSpeed = 1f;
	public Animation anim;

	void OnTriggerEnter(Collider other) {

		if(other.GetComponent<Collider>().tag == "Player")
		{
			GetComponent<Animation>().Play("button_push");
			anim["button_push"].speed = animSpeed;
		}

	}
}