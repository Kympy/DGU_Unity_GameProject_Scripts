using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    private AudioSource audio;
    public void Reload()
    {
        audio = GetComponent<AudioSource>();
        audio.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
