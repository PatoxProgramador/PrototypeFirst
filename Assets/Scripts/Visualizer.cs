using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visualizer : MonoBehaviour
{
    public float chase;
    public float speed;
    public float shot;

    public static float following;

    public static float distance;

    Opposing closestEnemy;

    void Start()
    {

        following = shot;
        
    }

    void Update()
    {

        FindClosestEnemy();

        if (closestEnemy != null)
        {

            Rotator();

        }

    }

    void FindClosestEnemy()
    {

        float distanceToClosestEnemy = Mathf.Infinity;

        closestEnemy = null;

        Opposing[] allEnemies = GameObject.FindObjectsOfType<Opposing>();

        foreach (Opposing currentEnemy in allEnemies)
        {

            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;

            if (distanceToEnemy < distanceToClosestEnemy)
            {

                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;

            }

        }

        //Debug.DrawLine(this.transform.position, closestEnemy.transform.position);

    }

    void Rotator()
    {
        // code taken from AI chase
        distance = Vector2.Distance(transform.position, closestEnemy.transform.position);

        Vector2 direction = closestEnemy.transform.position - transform.position;
        direction.Normalize();
        //angle to look at target
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (distance < chase)
        {

            if (distance < shot)
            {



            }
            else
            {

                transform.position = Vector2.MoveTowards(this.transform.position, closestEnemy.transform.position, speed * Time.deltaTime);

            }

            transform.rotation = Quaternion.Euler(Vector3.forward * angle);

        }

    }

}
