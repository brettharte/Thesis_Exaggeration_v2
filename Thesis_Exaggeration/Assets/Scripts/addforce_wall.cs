using UnityEngine;
using System.Collections;

public class addforce_wall : MonoBehaviour
{
    public Rigidbody wall;

    void Update()
    {
        //if (Input.GetKeyDown ("space")); 
        wall.GetComponent<Rigidbody>();
        StartCoroutine("waitTwoSeconds");

        //-- if (gameObject.tag == "cube")
        //--{DestroyObject(gameObject);
        //-- }
       }

        void FixedUpdate()
    {
        wall.AddForce(Vector3.back * 75f, ForceMode.Force);
    }

    IEnumerator waitTwoSeconds()
    {
        //	yield return new WaitForSeconds (1);
        //GameObject.FindGameObjectWithTag("cube");
        //foreach (GameObject target in gameObject); 
        //{
       	//if(other.gameObject.tag == "cube").AddComponent<Rigidbody> ();
        //}	
        //{
        yield return new WaitForSeconds(2);
        //wall.transform.DetachChildren();
        if (gameObject.tag == "cube")
        {
            wall.transform.DetachChildren();
            //DestroyObject(gameObject);
        }
    }
}
