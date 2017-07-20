using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall_move : MonoBehaviour
{

    public float animSpeed = 1f;
    public Animation anim;

    void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<Collider>().tag == "Player")
        {
            GetComponent<Animation>().Play("wall_move");
            anim["wall_move"].speed = animSpeed;


        }

    }
}