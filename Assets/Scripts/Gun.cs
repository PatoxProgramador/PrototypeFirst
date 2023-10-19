using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public GameObject bullet;
    public float shot;


    void Start()
    {
        
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && Visualizer.distance < shot)
        {

            Instantiate(bullet,transform.position, transform.rotation);

        }
        
    }

}
