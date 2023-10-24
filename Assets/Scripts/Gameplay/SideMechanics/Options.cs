using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{

    public GameObject optionsMenu;

    void Start()
    {

        optionsMenu.SetActive(false);

        Time.timeScale = 1.0f;

    }

    void Update()
    {
        
    }

    public void Menu()
    {

        optionsMenu.SetActive(true);

        Time.timeScale = 0f;

    }

    public void Back()
    {

        optionsMenu.SetActive(false);

        if (Pause.frozen.activeSelf) 
        {

            Time.timeScale = 0f;

        }
        else
        {

            Time.timeScale = 1f;

        }

        

    }

}
