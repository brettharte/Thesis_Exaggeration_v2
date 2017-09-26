using UnityEngine;
using System.Collections;

public class addforce_wall : MonoBehaviour
{
    public Rigidbody wall;

    void Update()
    {
        if (Input.GetKeyDown ("space")); 
        wall.GetComponent<Rigidbody>();
      //-- StartCoroutine("waitTwoSeconds");

    }

    void FixedUpdate()
    {
        wall.AddForce(Vector3.back * 75f, ForceMode.Force);
    }

   //-- IEnumerator waitTwoSeconds()
    //--{
        //	yield return new WaitForSeconds (1);
        //GameObject.FindGameObjectWithTag("cube");
        //foreach (GameObject target in gameObject); 
        //{
        //	gameObject.tag = "cube".AddComponent<Rigidbody> ();	
        //}	
        //{
       //-- yield return new WaitForSeconds(2);
        //--wall.transform.DetachChildren();
    }
//}
//}
