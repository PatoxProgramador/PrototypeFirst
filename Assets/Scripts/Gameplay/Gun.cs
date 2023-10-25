using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class Gun : MonoBehaviour
{

    public GameObject bullet;
    public float time;

    public bool available;

    public Visualizer hi;

    public AudioSource clicked;

    public AudioClip variety;

    void Start()
    {

        available = false;

        StartCoroutine(Fired(time));

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && hi.distance < hi.shot && available)
        {

            Instantiate(bullet,transform.position, transform.rotation);

            clicked.PlayOneShot(variety);

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

                yield return new WaitForSeconds(0.1f);

                if (Input.GetKeyDown(KeyCode.Space) && hi.distance < hi.shot && available)
                {

                    available = false;

                }

            }

        }

        StartCoroutine(Fired(time));

    }

}
