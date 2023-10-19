using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour{
    //target
    public GameObject player;
    //chasing variables
    public float chase;
    public float speed;
    public static float following;
    public static float distance;

    void Start(){

        following = chase;

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
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);

        }

    }

}
