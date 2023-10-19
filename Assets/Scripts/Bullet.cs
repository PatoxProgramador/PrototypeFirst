using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed;

    void Start()
    {

        Destroy(gameObject,1f);

    }

    void Update()
    {

        transform.Translate(Vector3.right * speed * Time.deltaTime);

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {

            Destroy(gameObject);

            Damaged.injured -= 10;

        }

    }

}
