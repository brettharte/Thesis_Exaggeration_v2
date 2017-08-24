using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableForABitFirst : MonoBehaviour {
    public GameObject target;
    public float secondsToWait = 2;

    void Awake() {
        if (target != null) {
            target.SetActive(false);
            StartCoroutine(EnableAfterWait(target));
        }
    }

    IEnumerator EnableAfterWait(GameObject gameObj) {
        yield return new WaitForSeconds(secondsToWait);
        gameObj.SetActive(true);
    }	
}
