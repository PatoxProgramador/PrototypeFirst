using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damaged : MonoBehaviour
{

    public float health;

    public static float injured;

    void Start()
    {

        injured = health;

    }

    void Update()
    {

        if (injured <= 0)
        {

            Destroy(gameObject);

        }

        health = injured;
        
    }

}
