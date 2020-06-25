using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour
{
    public Image HPBar;

    public static float currentHP = 1000f;
    private float maxHP = 1000f;
    private float hpRate;
    private float speed = 3f;
    private AudioSource reload;

    void Start()
    {
        currentHP = 1000f;
        HPBar = GetComponent<Image>();
        reload = GetComponentInParent<AudioSource>();
        HPBar.color = new Color(47 / 255f, 86 / 255f, 231 / 255f); // 초기 바 색상
    }

    void Update()
    {
        hpRate = currentHP / maxHP; // 체력 비율
        HPBar.fillAmount = Mathf.Lerp(HPBar.fillAmount, hpRate, Time.deltaTime * speed);

        if(Input.GetKeyDown(KeyCode.E) && BSlot.battery != 0)
        {
            currentHP += 500f;
            BSlot.battery -= 1;
            reload.Play();
        }

        // 체력게이지에 따라 색깔변경
        if(currentHP >= 1000f)
        {
            currentHP = 1000f;
        }
        if (currentHP <= 1000f)
        {
            HPBar.color = new Color(47 / 255f, 86 / 255f, 231 / 255f);
        }
        if (currentHP < 500f)
        {
            HPBar.color = new Color(243 / 255f, 125 / 255f, 0);
        }
        if (currentHP < 150f)
        {
            HPBar.color = Color.red;
        }
        if (currentHP == 0f)
        {
            currentHP = 0f;

        }
    }
}
