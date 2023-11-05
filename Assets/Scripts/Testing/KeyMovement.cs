using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class KeyMovement : MonoBehaviour
{

    float x, y, speed = 3;

    AIChase a;

    public Image ed;

    void Start()
    {

        ed.fillAmount = 0f;

        StartCoroutine(AB());
        
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

    IEnumerator AB()
    {

        ed.fillAmount += 0.25f;

        yield return new WaitForSeconds(0.75f);

        if (ed.fillAmount >0.9)
        {

            ed.fillAmount = 0.0f;

        }

        StartCoroutine(AB());

    }

}
