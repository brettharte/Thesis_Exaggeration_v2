using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Move_In : MonoBehaviour {

	public float animSpeed = 1f;
	public Animation anim;

	void OnTriggerEnter(Collider other) {

		if(other.GetComponent<Collider>().tag == "Player")
		{
			GetComponent<Animation>().Play("Wall_Move_In");
			anim["Wall_Move_In"].speed = animSpeed;

		}

	}
}