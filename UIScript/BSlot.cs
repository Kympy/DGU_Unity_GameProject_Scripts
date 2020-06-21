using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BSlot : MonoBehaviour
{
    public static int battery;
    private TextMeshProUGUI bat;
    void Start()
    {
        battery = 0;
        bat = this.GetComponentInChildren<TextMeshProUGUI>();
        bat.text = battery.ToString();
    }

    void Update()
    {
        bat.text = battery.ToString();
    }
}
