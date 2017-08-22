using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DONT_DESTORYGame_Env_Player : MonoBehaviour {

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Game_Env_Player");
        if (objs.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

}
