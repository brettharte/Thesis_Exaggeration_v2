using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addtorque : MonoBehaviour
{
    private Rigidbody wall;


    void Start()
    {
        wall = GetComponent<Rigidbody>();
        StartCoroutine(AddTorquePeriodically());
    }

    IEnumerator AddTorquePeriodically()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            //wall.AddForce(Vector3.forward * 1000f, ForceMode.Force);
            wall.AddTorque(Vector3.left * 10000000f, ForceMode.Force);
        }
    }
}
