using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Winner : MonoBehaviour
{

    public Text wins;

    void Start()
    {

        wins.text = Result.result;
        
    }

    void Update()
    {
        
    }

}
