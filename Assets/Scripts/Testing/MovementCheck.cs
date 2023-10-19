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

    void Start()
    {

        target = transform.position;
        
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

        StartCoroutine(Timer(wait));

    }

    IEnumerator Timer(float time)
    {

        if (distance < 1)
        {

            yield return new WaitForSeconds(time);

            if (distance < 1)
            {

                print("NOT MOVING");

            }
            else
            {

                StartCoroutine(Timer(time));

            }

        }

    }

}
