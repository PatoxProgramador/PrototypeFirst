using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardMovement : MonoBehaviour{

    public float playerSpeed;
    
    void Start(){


        
    }

    void Update(){

        float x = Input.GetAxisRaw("Horizontal") * playerSpeed * Time.deltaTime;
        float y = Input.GetAxisRaw("Vertical") * playerSpeed * Time.deltaTime;

        transform.Translate(-y,x,0);

    }

}
