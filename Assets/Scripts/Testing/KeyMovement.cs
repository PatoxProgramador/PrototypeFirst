using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KeyMovement : MonoBehaviour
{

    float x, y, speed = 3;

    AIChase a;

    void Start()
    {

        
        
    }

    void Update()
    {

        x = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        y = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;

        transform.Translate(x,y,0);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player") {

            a = collision.gameObject.GetComponent<AIChase>();

            StartCoroutine(b());    

        }

    }
    
    IEnumerator b()
    {

        a.enabled = false;

        yield return new WaitForSeconds(3f);

        a.enabled = true;

    }

}
