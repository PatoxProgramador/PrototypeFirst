using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class Gun : MonoBehaviour
{

    public GameObject bullet;
    public float time;

    public bool available;

    public Visualizer hi;

    public AudioSource clicked;

    public AudioClip variety;

    public Image a;

    void Start()
    {

        a.fillAmount = 0.0f;

        available = false;

        StartCoroutine(Fired(time));
        StartCoroutine(Shoot());

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && hi.distance < hi.shot && available)
        {

            Instantiate(bullet,transform.position, transform.rotation);

            clicked.PlayOneShot(variety);

            available = false;

            a.fillAmount = 0.0f;

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

                    a.fillAmount = 0.0f;

                }

            }

        }

        StartCoroutine(Fired(time));

    }

    IEnumerator Shoot()
    {

        a.fillAmount += 0.34f;

        yield return new WaitForSeconds(0.25f);

        StartCoroutine(Shoot());

    }

}
