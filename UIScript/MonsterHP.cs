using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHP : MonoBehaviour
{
    public Slider hpSlider;
    public MonsterControl monsterControl;
    public float speed = 2f;
    public float currentHP; // 초기 체력
    public float maxHP = 100f; // 최대 체력
    public GameObject alienNumber;

    private CanvasGroup hpCanvas;
    private float hpRate;
    private float timer; // 몬스터 ui지속시간
    private CapsuleCollider alien;
    void Start()
    {
        hpSlider = GameObject.Find("HPSlider").GetComponent<Slider>();
        monsterControl = GameObject.Find(alienNumber.name).GetComponent<MonsterControl>();
        alien = GameObject.Find(alienNumber.name).GetComponent<CapsuleCollider>();
        currentHP = maxHP; // 초기 체력 설정
        hpCanvas = GameObject.Find("MonsterHPCanvas").GetComponent<CanvasGroup>();
        hpCanvas.alpha = 0f; // 몬스터 hp ui 안보이게
    }

    void Update()
    {
        hpRate = currentHP / maxHP;
        hpSlider.value = Mathf.Lerp(hpSlider.value, hpRate, Time.deltaTime * speed);

        if(currentHP <= 0f)
        {
            currentHP = 0f;
            alien.enabled = false; // 죽으면 콜라이더 사라짐
            monsterControl.isDead = true; // 몬스터컨트롤 스크립트의 isDead라는 bool값 변경
            timer += Time.deltaTime;
            if (timer > 4f) // 죽는모션 끝나고 hp ui 사라짐
            {
                hpCanvas.alpha = 0;
            }
        }
    }
}
