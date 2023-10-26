using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damaged : MonoBehaviour
{

    [SerializeField] float health, maxHealth = 100;
    [SerializeField] private GameObject substitute;


    AudioSource clicked;

    public AudioClip variety;

    public Slider slider;

    private void Start()
    {

        clicked = GetComponent<AudioSource>();

        health = maxHealth;

        slider.value = health;

    }

    public void TakeDamage(float damageAmount)
    {

        health -= damageAmount;
        slider.value = health;

        clicked.PlayOneShot(variety);
            
        if (health <= 0)
        {

            Instantiate(substitute, transform.position, transform.rotation) ;

            Destroy(gameObject);

        }
        
    }

}
