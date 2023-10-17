using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visualizer : MonoBehaviour
{

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

        Debug.DrawLine(this.transform.position, closestEnemy.transform.position);

    }

}
