using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed;

    AudioSource clicked;

    public AudioClip variety;

    void Start()
    {

       clicked = GetComponent<AudioSource>();

        Destroy(gameObject,1f);

    }

    void Update()
    {

        transform.Translate(Vector3.right * speed * Time.deltaTime);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player" && collision.gameObject.TryGetComponent<Damaged>(out Damaged enemy))
        {

            enemy.TakeDamage(10);
            clicked.PlayOneShot(variety);

        }

        StartCoroutine(Vanished());

    }

    IEnumerator Vanished()
    {

        yield return new WaitForSeconds(0.1f);

        Destroy(gameObject);

    }

}
