using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToDestroy : MonoBehaviour{
    // selected list
    public static List<ToDestroy> moveableObject = new List<ToDestroy>();
    // wheter is selected or not
    public bool isSelected;
    // movement
    public float speed = 5f;
 
    private Vector3 target;

    void Start(){

        moveableObject.Add(this);
        target = transform.position;
        
    }

    void Update(){
        //movement of selected object
        if (Input.GetMouseButtonDown(1) && isSelected){

            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;

        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

    }

    public void OnMouseDown(){
        // selection process
        isSelected = !isSelected;

        if (isSelected) {

            gameObject.GetComponent<SpriteRenderer>().color = Color.green;

        }
        else{

            gameObject.GetComponent<SpriteRenderer>().color = Color.white;

        }
        
        // avoids multiple selections
        foreach (ToDestroy obj in moveableObject){

            if (obj != this && obj != null){

                obj.isSelected = false;
                obj.gameObject.GetComponent<SpriteRenderer>().color = Color.white;

            }

        }

    }

}
