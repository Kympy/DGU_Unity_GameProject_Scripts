using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Explain : MonoBehaviour
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
                text.text = "- WHERE AM I ? -";
                break;
            case 2:
                text.text = "Look around the ship.";
                break;
            case 3:
                text.text = "You will be find a battery";
                break;
            case 4:
                text.text = "It can use only in this stage.";
                break;
            case 5:
                text.text = "Press E = Charge durability\r\nPress R = Charge lazer\r\nPress Q = Shooting Mode";
                break;
            case 6:
                text.text = "Find a portal.";
                break;
            default:
                canvas.alpha = 0;
                
                break;
        }
    }
}
