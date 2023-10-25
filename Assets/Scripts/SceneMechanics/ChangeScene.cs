using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public string sceneName;

    public GameObject dJ;

    public AudioSource[] party = new AudioSource[2];

    void Start()
    {

        dJ = GameObject.FindGameObjectWithTag("Music");

        party = dJ.GetComponents<AudioSource>();

        if (sceneName.Equals("Instructions") || sceneName.Equals("StartScene"))
        {

            party[0].volume = 1f;
            party[1].volume = 0f;


        }
        
    }

    void Update()
    {

    }

    public void changeScene()
    {

        SceneManager.LoadScene(sceneName);

    }

    public void QuitGame()
    {

        Application.Quit();

    }

}
