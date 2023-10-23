using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next : MonoBehaviour
{

    public string sceneName;

    public float time;

    void Start()
    {

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
