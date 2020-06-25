using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Explain5 : MonoBehaviour
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
                text.text = "- WHO ARE YOU -";
                break;
            case 2:
                text.text = "If you go out,\r\nthe boss will attack you.";
                break;
            case 3:
                text.text = "If you hide inside here,";
                break;
            case 4:
                text.text = "You will safe.";
                break;
            default:
                canvas.alpha = 0;
                
                break;
        }
    }
}
