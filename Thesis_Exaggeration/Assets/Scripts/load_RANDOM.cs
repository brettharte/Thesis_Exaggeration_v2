using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class load_RANDOM : MonoBehaviour {

void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Application.LoadLevel(Random.Range(3, 5));
        }
    }
}