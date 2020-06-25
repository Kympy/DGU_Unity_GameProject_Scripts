using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Explain2 : MonoBehaviour
{
    private TextMeshProUGUI text;
    private CanvasGroup canvas;
    private AudioSource select;
    private int page = 1;
    void Start()
    {
        select = GetComponent<AudioSource>();
        canvas = GetComponent<CanvasGroup>();
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        canvas.alpha = 1;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            select.Play();
            page += 1;
        }
        switch(page)
        {
            case 1:
                text.text = "- KILL ALL -";
                break;
            case 2:
                text.text = "I have to escape this planet.";
                break;
            default:
                canvas.alpha = 0;
                break;
        }
    }
}
