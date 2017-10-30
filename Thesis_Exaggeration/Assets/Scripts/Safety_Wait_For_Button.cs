using UnityEngine;
using System.Collections;
 
public class Safety_Wait_For_Button : MonoBehaviour
{
    private GameObject initiallyDeactived;

    private void Awake()
    {
        // make sure the button and main voice over is disabled for now:
        initiallyDeactived = GameObject.Find("Initially_TBDeactivated");
        initiallyDeactived.SetActive(false);
    }

    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.One) || Input.GetKeyDown(KeyCode.Space))
        {
            // set the scene up with button and switchable hands:
            GameObject.Find("LeftHandAnchor").GetComponent<switchHands>().enabled = true;
            GameObject.Find("RightHandAnchor").GetComponent<switchHands>().enabled = true;
            initiallyDeactived.SetActive(true);
            // finally destroy ourselves:
            Destroy(this.gameObject);
        }
    }
}
