using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    public static bool pause = false;

    public GameObject pauseMenu;

    public AudioSource buttons;

    void Start()
    {

        pause = false;

        pauseMenu.SetActive(false);

        Time.timeScale = 1.0f;

    }

    void Update()
    {

        if (Input.GetKey(KeyCode.Escape))
        {

            
            if(!pause)
            {

                Paused();

            }

        }
        
    }

    public void Resume()
    {

        pause = false;

        buttons.Play();

        pauseMenu.SetActive(false);

        Time.timeScale = 1.0f;

    }
    void Paused()
    {

        pause = true;

        buttons.Play();

        pauseMenu.SetActive(true);

        Time.timeScale = 0f;

    }

    public void Restart()
    {

        pause = false;

        buttons.Play();

        pauseMenu.SetActive(false);

        Time.timeScale = 1.0f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

}
