using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class ToDestroy : MonoBehaviour{
    // selected list
    public static List<ToDestroy> moveableObject = new List<ToDestroy>();
    // wheter is selected or not
    public bool isSelected;
    // movement
    public float speed = 5f;
 
    private Vector3 target;

    private float distance;

    bool flag;

    public float wait;

    AudioSource clicked;

    public AudioClip [] variety = new AudioClip[2];

    Visualizer freeze;

    void Start(){

        clicked = GetComponent<AudioSource>();

        clicked.PlayOneShot(variety[1]);

        moveableObject.Add(this);
        target = transform.position;

        StartCoroutine(MovementCheck(wait));

        flag = false;

    }

    void Update(){
        //movement of selected object

        distance = Vector2.Distance(transform.position, target);

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

            clicked.PlayOneShot(variety[0]);

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

    IEnumerator MovementCheck( float time)
    {

        flag = false;

        if (distance < 0.1)
        {

            yield return new WaitForSeconds(time);

            if (distance < 0.1 && gameObject.TryGetComponent<Damaged>(out Damaged enemy))
            {

                //print("NOT MOVING");
                enemy.TakeDamage(10f);

            }
            else
            {
            }

        }
        else
        {

            while (!flag)
            {

                yield return new WaitForSeconds(0.5f);

                if (distance < 0.1)
                {

                    flag = true;

                }

            }

        }

        StartCoroutine(MovementCheck(wait));

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Cowboy")
        {

            freeze = collision.gameObject.GetComponent<Visualizer>();

            StartCoroutine(Freezer(collision.gameObject));

        }

    }

    IEnumerator Freezer(GameObject a)
    {

        freeze.enabled = false;

        yield return new WaitForSeconds(3f);

        if (a != null)
        {

            freeze.enabled = true;

        }

       

    }

}
