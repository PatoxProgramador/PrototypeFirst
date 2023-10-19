using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovementCheck : MonoBehaviour
{

    Vector2 previousSpot;
   
    private float distance;


    void Start()
    {

        previousSpot = transform.position;
        
    }
    void Update()
    {

        distance = Vector2.Distance(transform.position, previousSpot);

    }

}
