using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{

    Image fondo;
    public Text change;

    public Sprite[] side = new Sprite[2];

    void Start()
    {
        
        fondo = GetComponent<Image>();

        if (Result.result.Equals("Red wins"))
        {

            fondo.sprite = side[1];

            change.color = Color.red;

        }
        else if (Result.result.Equals("White wins"))
        {

            fondo.sprite = side[0];

            change.color = Color.green;

        }

    }

    void Update()
    {
        
    }
}
