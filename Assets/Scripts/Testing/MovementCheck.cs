using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MovementCheck : MonoBehaviour
{
   
    private float distance;

    private Vector3 target;

    public float speed = 5f;
    public float wait;

    bool flag  = false;

    void Start()
    {

        target = transform.position;

        StartCoroutine(Timer(wait));

        flag = false;

    }
    void Update()
    {

        distance = Vector2.Distance(transform.position, target);

        if (Input.GetMouseButtonDown(1))
        {

            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;

        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

    }

    IEnumerator Timer(float time)
    {

        flag = false;

        if (distance < 0.1)
        {

            yield return new WaitForSeconds(time);

            if (distance < 0.1 && gameObject.TryGetComponent<Damaged>(out Damaged enemy))
            {

                //print("NOT MOVING");
                enemy.TakeDamage(10f);

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

                if (distance < 0.1)
                {

                    flag = true;

                }

            }

        }

        StartCoroutine(Timer(wait));

    }

}
