using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class Gun : MonoBehaviour
{

    public GameObject bullet;
    public float time;

    private bool available;

    void Start()
    {

        available = false;

        StartCoroutine(Fired(time));

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && Visualizer.distance < Visualizer.following && available)
        {

            Instantiate(bullet,transform.position, transform.rotation);

            available = false;

        }
        
    }

    IEnumerator Fired(float time)
    {

        if (!available)
        {

            yield return new WaitForSeconds(time);

            available = true;
        }
        else
        {

            while (available)
            {

                yield return new WaitForSeconds(0.5f);

                if (Input.GetKeyDown(KeyCode.Space) && Visualizer.distance < Visualizer.following && available)
                {

                    available = false;

                }

            }

        }

        StartCoroutine(Fired(time));

    }

}
