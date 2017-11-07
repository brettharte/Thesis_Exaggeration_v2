using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class load_RANDOM : MonoBehaviour {

    private GameObject Wall_Collider_Fall;
    private GameObject Falling_wall;

    void Start()
    {
        Wall_Collider_Fall = GameObject.Find("Wall_Collider_Fall");
        Wall_Collider_Fall.gameObject.SetActive(false);
        Falling_wall = GameObject.Find("Falling_wall");
        Falling_wall.gameObject.SetActive(false);
    }

void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
        Wall_Collider_Fall.gameObject.SetActive(true);
        Falling_wall.gameObject.SetActive(true);
    }
    //}

   // void OnTriggerEnter(Collider col)
   // {
     //   if (col.gameObject.tag == "Player")
        {

            StartCoroutine(newshapes());

        }
    }

    IEnumerator newshapes()
        
        {
        yield return new WaitForSeconds(10);
        Application.LoadLevel(Random.Range(3, 7));
        }
}