using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhenAttacked : MonoBehaviour
{
    private CanvasGroup hpCanvas;
    public MonsterControl monster;
    public MonsterHP monsterHp;
    public float damage = 5f; // 한발당 받는 데미지

    public GameObject effect;
    public GameObject effectPosition;
    public GameObject alienNumber;

    private GameObject playingEffect;

    void Start()
    {
        monsterHp = GameObject.Find("MonsterHPCanvas").GetComponent<MonsterHP>();
        monster = GameObject.Find(alienNumber.name).GetComponent<MonsterControl>();
        hpCanvas = GameObject.Find("MonsterHPCanvas").GetComponent<CanvasGroup>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject); // 총알에 맞으면 총알삭제
            hpCanvas.alpha = 1; // 몬스터 체력바 보이기
            monsterHp.currentHP -= damage; // 맞으면 체력 데미지만큼 감소
            playingEffect = Instantiate(effect, effectPosition.transform.position, effectPosition.transform.rotation);
            Destroy(playingEffect, 1f);
            monster.currentState = MonsterControl.CurrentState.hit; // 몬스터상태를 hit로 변경
        }
    }
}