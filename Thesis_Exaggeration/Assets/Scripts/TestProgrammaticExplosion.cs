using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestProgrammaticExplosion : MonoBehaviour {
    public FracturedObject objectToExplode;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionEnter(Collision other)
    {
        Debug.Log("CollisionEnter explosion via code");
        objectToExplode.Explode(other.contacts[0].point, 100);    
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("TriggerEnter explosion via code");
        objectToExplode.Explode(other.ClosestPointOnBounds(other.gameObject.transform.position), 100);
    }
}
