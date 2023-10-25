using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damaged : MonoBehaviour
{

    [SerializeField] float health, maxHealth = 100;
    [SerializeField] private GameObject substitute;

    public Text visualHealth;

    AudioSource clicked;

    public AudioClip variety;

    private void Start()
    {

        clicked = GetComponent<AudioSource>();

        health = maxHealth;

        visualHealth.text = health.ToString();

    }

    public void TakeDamage(float damageAmount)
    {

        health -= damageAmount;
        visualHealth.text = health.ToString();

        clicked.PlayOneShot(variety);
            
        if (health <= 0)
        {

            Instantiate(substitute, transform.position, transform.rotation) ;

            Destroy(gameObject);

        }
        
    }

}
