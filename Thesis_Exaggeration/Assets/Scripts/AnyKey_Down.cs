using UnityEngine;
using System.Collections;
 
public class AnyKey_Down : MonoBehaviour
{

    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.One))
        {
            Application.LoadLevel("touch_control");
        }
    }
}