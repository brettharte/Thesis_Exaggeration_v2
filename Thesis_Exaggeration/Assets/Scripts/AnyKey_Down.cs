using UnityEngine;
using System.Collections;
 
public class AnyKey_Down : MonoBehaviour
{

    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.One))
        {
            // set the scene up with button and switchable hands:
            //GameObject.Find("button_stand").SetActive(true);
           // GameObject.Find("Touch_controller_L_standard").SetActive(false);
           // GameObject.Find("Touch_controller_R_standard").SetActive(false);
            //GameObject.Find("Voice_Over").SetActive(true);
           // GameObject.Find("LeftHandAnchor").GetComponent<switchHands>().enabled = true;
            //GameObject.Find("RightHandAnchor").GetComponent<switchHands>().enabled = true;
            // finally destroy ourselves:
            Destroy(this.gameObject);
        }
    }
}
