using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class load_RANDOM : MonoBehaviour {


   

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {

            StartCoroutine(newshapes());

        }
    }

    IEnumerator newshapes()
        
        {
        yield return new WaitForSeconds(4);
        Application.LoadLevel(Random.Range(3, 6));
        }
}