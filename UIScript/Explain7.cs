using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Explain7 : MonoBehaviour
{
    private TextMeshProUGUI text;
    private CanvasGroup canvas;
    private AudioSource select;
    private int page = 1;
    public bool zone = false;
    private CanvasGroup end;
    void Start()
    {
        select = GetComponent<AudioSource>();
        canvas = GetComponent<CanvasGroup>();
        text = GetComponentInChildren<TextMeshProUGUI>();
        end = GameObject.Find("PlayerDead").GetComponent<CanvasGroup>();
        canvas.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && zone == true)
        {
            select.Play();
            page += 1;
        }
        switch(page)
        {
            case 1:
                text.text = "- I'M DEAD -";
                break;
            case 2:
                text.text = "You were deliberately murdered,";
                    break;
            case 3:
                text.text = "The process so far is research\r\nthe memory in your body.";
                    break;
            default:
                canvas.alpha = 0;
                end.alpha = 1;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                break;
        }
    }
}
