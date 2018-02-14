using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadPrefab : MonoBehaviour {
    public GameObject toBeReplaced;
    public GameObject prefabToReload;

	void Update () {
        if (toBeReplaced != null && prefabToReload != null) {
            if (Input.GetKeyDown(KeyCode.R)) {
                Vector3 oldPos = toBeReplaced.transform.position;
                Quaternion oldRot = toBeReplaced.transform.rotation;
                Transform oldParent = toBeReplaced.transform.parent;
                Destroy(toBeReplaced);
                toBeReplaced = Instantiate(prefabToReload, oldPos, oldRot, oldParent) as GameObject;
            }
        }
    }
}
