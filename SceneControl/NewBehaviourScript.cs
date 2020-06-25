using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zone : MonoBehaviour
{
    private CanvasGroup canvas;
    private Explain7 val;
    void Start()
    {
        canvas = GetComponentInChildren<CanvasGroup>();
        val = GetComponentInChildren<Explain7>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            val.zone = true;
            canvas.alpha = 1;
        }
    }
}
