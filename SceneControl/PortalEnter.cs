using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalEnter : MonoBehaviour
{
    public GameObject player;

    bool isPlayerAtPortal = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            isPlayerAtPortal = true;
        }
    }
    private void Update()
    {
        if(isPlayerAtPortal == true)
        {
            SceneManager.LoadScene(1);
        }
    }

}