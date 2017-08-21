using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class load_RANDOM : MonoBehaviour {

void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "player")
        {
            Application.LoadLevel(Random.Range(1, 4));
        }
    }
}