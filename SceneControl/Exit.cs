using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
    private AudioSource audio;
    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    public void OnClickExit()
    {
        audio.Play();
        Application.Quit();
    }
}
