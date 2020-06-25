using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cheats : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            SceneManager.LoadSceneAsync(1);
        }
        else if (Input.GetKeyDown(KeyCode.F2))
        {
            SceneManager.LoadSceneAsync(3);
        }
        else if (Input.GetKeyDown(KeyCode.F3))
        {
            SceneManager.LoadSceneAsync(4);
        }
        else if (Input.GetKeyDown(KeyCode.F4))
        {
            SceneManager.LoadSceneAsync(5);
        }
        else if (Input.GetKeyDown(KeyCode.F5))
        {
            SceneManager.LoadSceneAsync(6);
        }
        else if (Input.GetKeyDown(KeyCode.F6))
        {
            SceneManager.LoadSceneAsync(7);
        }
        else if (Input.GetKeyDown(KeyCode.F7))
        {
            SceneManager.LoadSceneAsync(8);
        }
        if(Input.GetKeyDown(KeyCode.Equals))
        {
            PlayerHPBar.currentHP += 4000f;
        }
    }
}
