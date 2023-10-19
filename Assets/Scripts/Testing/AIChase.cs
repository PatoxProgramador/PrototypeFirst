using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour{
    //target
    GameObject player;
    //chasing variables
    public float chase;
    private float distance;

    void Start(){
        


    }
 
    void Update(){
        //setting the distance
        distance = Vector2.Distance(transform.position, player.transform.position);

        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        //angle to look at target
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (distance < chase){

            //moving and rotation to target
            //transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, chase * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);

        }

    }

}
