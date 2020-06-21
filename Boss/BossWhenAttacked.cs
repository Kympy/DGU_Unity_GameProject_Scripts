using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BossWhenAttacked : MonoBehaviour
{
    public float damage = 5f; // 한발당 받는 데미지
    public GameObject effect; // 피격 이펙트
    public GameObject effectPosition; // 피격 이펙트 위치

    private CanvasGroup hpCanvas;
    private MonsterHP monsterHp;
    private GameObject playingEffect;


    void Start()
    {
        monsterHp = this.GetComponentInChildren<MonsterHP>();
        hpCanvas = this.GetComponentInChildren<CanvasGroup>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet" && monsterHp.currentHP == 165f || monsterHp.currentHP == 120f || 
            monsterHp.currentHP == 100f || monsterHp.currentHP == 70f || monsterHp.currentHP == 20f)
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject); // 총알에 맞으면 총알삭제
            hpCanvas.alpha = 1; // 몬스터 체력바 보이기
            monsterHp.currentHP -= damage;// 맞으면 체력 데미지만큼 감소
            Debug.Log(monsterHp.currentHP);
            playingEffect = Instantiate(effect, effectPosition.transform.position, effectPosition.transform.rotation);
            Destroy(playingEffect, 1f); // 피격 이펙트 1초 재생후 삭제
        }
    }
}