using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Startt : MonoBehaviour
{
    private AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    public void ClickStart()
    {
        audio.Play();
        SceneManager.LoadSceneAsync(1);
    }


}
