using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class Sucker : MonoBehaviour
{

   [SerializeField] float health, maxHealth = 100;

    public Slider slider;

    public float wait;

    bool flag = false;

    public Visualizer hi;

    AudioSource clicked;

    public AudioClip[]variety = new AudioClip[2];

    private void Start()
    {

        clicked = GetComponent<AudioSource>();

        health = maxHealth;
        slider.value = health;

        StartCoroutine(Draining(wait));

    }

    public void TakeDamage(float damageAmount)
    {

        health -= damageAmount;
        
        slider.value = health;

        if (health <= 0)
        {

            StartCoroutine(Vanished());

        }

    }

    IEnumerator Draining(float time)
    {

        flag = false;

        if (hi.distance < hi.shot)
        {
            yield return new WaitForSeconds(time);

            if (hi.distance < hi.shot)
            {

                //print("NOT MOVING");
                TakeDamage(10f);

                clicked.PlayOneShot(variety[0]);

            }
            else
            {

            }

        }
        else
        {

            while (!flag)
            {

                yield return new WaitForSeconds(0.5f);

                if (hi.distance < hi.shot)
                {

                    flag = true;

                }

            }

        }

        StartCoroutine(Draining(wait));

    }

    IEnumerator Vanished()
    {

        clicked.PlayOneShot(variety[1]);

        yield return new WaitForSeconds(0.1f);

        Destroy(gameObject);

    }

}
