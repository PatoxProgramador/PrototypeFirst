using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next : MonoBehaviour
{

    public string sceneName;

    public float time;

    public GameObject dJ;

    public AudioSource[] party = new AudioSource[2];

    void Start()
    {

        dJ = GameObject.FindGameObjectWithTag("Music");

        party = dJ.GetComponents<AudioSource>();

        party[0].volume = 0f;
        party[1].volume = 1f;

        StartCoroutine(Timer(time));
        
    }

    void Update()
    {
        
    }

    IEnumerator Timer(float time)
    {

        yield return new WaitForSeconds(time);

        SceneManager.LoadScene(sceneName);

    }

}
