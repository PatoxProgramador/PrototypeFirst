using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThreshHold : MonoBehaviour
{

    public float aplhaThreshold = 0.1f;

    void Start()
    {

        this.GetComponent<Image>().alphaHitTestMinimumThreshold = aplhaThreshold;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
