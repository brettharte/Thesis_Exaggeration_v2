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
        wall.AddTorque(Vector3.back * 75f, ForceMode.Force);
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
        if (gameObject.tag == "wall")
        {
            wall.transform.DetachChildren();
            //DestroyObject(gameObject);
        }


        {
            yield return new WaitForSeconds(5);
            //wall.transform.DetachChildren();
            //if (gameObject.tag == "cube")
            {
               // GameObject myGameObject = new GameObject("cube");// Make a new GO.
             //  gameObject.AddComponent<Rigidbody>(); // Add the rigidbody.
                //RigidBody.mass = 5; // Set the GO's mass to 5 via the Rigidbody.;
            }
        }
    }
}
