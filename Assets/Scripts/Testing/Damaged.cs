using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damaged : MonoBehaviour
{

    [SerializeField] float health, maxHealth = 100;
    [SerializeField] private GameObject substitute;

    public Text visualHealth;

    private void Start()
    {

        health = maxHealth;

        visualHealth.text = health.ToString();

    }

    public void TakeDamage(float damageAmount)
    {

        health -= damageAmount;
        visualHealth.text = health.ToString();
            
        if (health <= 0)
        {

            Instantiate(substitute, transform.position, transform.rotation) ;
            Destroy(gameObject);

        }
        
    }

}
