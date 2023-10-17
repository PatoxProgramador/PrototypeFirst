using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visualizer : MonoBehaviour
{
    public float chase;

    private float distance;

    void Start()
    {
        
    }

    void Update()
    {

        FindClosestEnemy();

    }

    void FindClosestEnemy()
    {

        float distanceToClosestEnemy = Mathf.Infinity;

        Opposing closestEnemy = null;

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
        // code taken from AI chase
        distance = Vector2.Distance(transform.position, closestEnemy.transform.position);

        Vector2 direction = closestEnemy.transform.position - transform.position;
        direction.Normalize();
        //angle to look at target
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (distance < chase)
        {

            transform.rotation = Quaternion.Euler(Vector3.forward * angle);

        }

        //Debug.DrawLine(this.transform.position, closestEnemy.transform.position);

    }

}
