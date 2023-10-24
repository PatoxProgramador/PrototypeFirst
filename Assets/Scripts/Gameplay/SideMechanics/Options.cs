using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{

    public GameObject optionsMenu;

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


    }

    public void Back()
    {

        optionsMenu.SetActive(false);
        

    }

    public void SetQuality(int qualityIndex)
    {

        QualitySettings.SetQualityLevel(qualityIndex);

    }

}
