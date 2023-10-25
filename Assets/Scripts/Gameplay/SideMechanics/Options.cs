using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{

    public GameObject optionsMenu;

    public AudioSource buttons;

    void Start()
    {

        optionsMenu.SetActive(false);

    }

    void Update()
    {
        
    }

    public void Menu()
    {

        optionsMenu.SetActive(true);

        buttons.Play();

    }

    public void Back()
    {

        optionsMenu.SetActive(false);

        buttons.Play();

    }

    public void SetQuality(int qualityIndex)
    {

        QualitySettings.SetQualityLevel(qualityIndex);

    }

}
