using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{

    void Awake()
    {

        GameObject[] dancing = GameObject.FindGameObjectsWithTag("Music");

        if (dancing.Length > 1)
        {

            Destroy(this.gameObject);

        }
        DontDestroyOnLoad(this.gameObject);
        
    }

}
