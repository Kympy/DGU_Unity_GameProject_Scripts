﻿using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ZombieAttacked : MonoBehaviour
{
    public float damage = 5f; // 한발당 받는 데미지
    public GameObject effect; // 피격 이펙트
    public GameObject effectPosition; // 피격 이펙트 위치

    private CanvasGroup hpCanvas;
    private ZombieHP zombieHp;
    private GameObject playingEffect;


    void Start()
    {
        zombieHp = this.GetComponentInChildren<ZombieHP>();
        hpCanvas = this.GetComponentInChildren<CanvasGroup>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject); // 총알에 맞으면 총알삭제
            hpCanvas.alpha = 1; // 몬스터 체력바 보이기
            zombieHp.currentHP -= damage;// 맞으면 체력 데미지만큼 감소
            Debug.Log(zombieHp.currentHP);
            playingEffect = Instantiate(effect, effectPosition.transform.position, effectPosition.transform.rotation);
            Destroy(playingEffect, 1f); // 피격 이펙트 1초 재생후 삭제
        }
    }
}