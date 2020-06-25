using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LSlot: MonoBehaviour
{
    public static int lazer;
    private TextMeshProUGUI laz;
    private AudioSource reload;
    void Start()
    {
        lazer = 0;
        laz = this.GetComponentInChildren<TextMeshProUGUI>();
        reload = GetComponent<AudioSource>();
        laz.text = lazer.ToString();
    }

    void Update()
    {
        laz.text = lazer.ToString();
    }
}
