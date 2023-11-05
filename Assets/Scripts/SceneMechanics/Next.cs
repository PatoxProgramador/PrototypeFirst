using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Next : MonoBehaviour
{

    public string sceneName;

    public float time;

    public GameObject dJ;

    public AudioSource[] party = new AudioSource[2];

    public GameObject skip;

    void Start()
    {

        skip.SetActive(false);

        dJ = GameObject.FindGameObjectWithTag("Music");

        party = dJ.GetComponents<AudioSource>();

        party[0].volume = 0f;
        party[1].volume = 0.2f;

        StartCoroutine(Timer(time));
        
    }

    void Update()
    {
        
    }

    IEnumerator Timer(float time)
    {

        yield return new WaitForSeconds(time);

        skip.SetActive(true);

    }

    public void Pass()
    {

        SceneManager.LoadScene(sceneName);

    }

}
