using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class Sucker : MonoBehaviour
{

   [SerializeField] float health, maxHealth = 100;

    public Text visualHealth;

    public float wait;

    bool flag = false;

    private void Start()
    {

        health = maxHealth;

        visualHealth.text = health.ToString();

        StartCoroutine(Draining(wait));

    }

    public void TakeDamage(float damageAmount)
    {

        health -= damageAmount;
        visualHealth.text = health.ToString();

        if (health <= 0)
        {

            Destroy(gameObject);

        }

    }

    IEnumerator Draining(float time)
    {

        flag = false;

        if (AIChase.distance < AIChase.following)
        {
            yield return new WaitForSeconds(time);

            if (AIChase.distance < AIChase.following)
            {

                //print("NOT MOVING");
                TakeDamage(10f);

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

                if (AIChase.distance < AIChase.following)
                {

                    flag = true;

                }

            }

        }

        StartCoroutine(Draining(wait));

    }

}
