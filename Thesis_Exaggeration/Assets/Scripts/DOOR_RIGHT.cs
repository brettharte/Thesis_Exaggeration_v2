using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOOR_RIGHT : MonoBehaviour {

	public float animSpeed = 1f;
	public Animation anim;

    void OnTriggerEnter(Collider other) {

		if(other.GetComponent<Collider>().tag == "Player")
		{
			GetComponent<Animation>().Play("Right_Door_Open");
			anim["Right_Door_Open"].speed = animSpeed;


        }

	}
}