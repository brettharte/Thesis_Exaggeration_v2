using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateCube : MonoBehaviour {

    public Transform[] teleport;
    public GameObject[] prefeb;

    void Start()
    { //this will spawn only one prefeb, if you want call it many time, create  a new function and call it or create for loop
        int tele_num = Random.Range(0, 8);
        int prefeb_num = Random.Range(0, 3);

        Instantiate(prefeb[prefeb_num], teleport[tele_num].position, teleport[tele_num].rotation);

    }

  

}
