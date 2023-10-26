using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{

    public static string result;

    public string sceneName;

    public Damaged[] allEnemies;
    public Sucker[] allAllies;

    void Start()
    {

        result = "";
        
    }

    void Update()
    {

        allAllies = GameObject.FindObjectsOfType<Sucker>();
        allEnemies = GameObject.FindObjectsOfType<Damaged>();

            if (allEnemies.Length < 1)
        {

            result = "RIPD wins";

            changeScene();

        }

        else if (allAllies.Length < 1)
        {

            result = "Deados wins";

            changeScene();

        }


    }

    public void changeScene()
    {

        SceneManager.LoadScene(sceneName);

    }

}
