using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhenAttacked : MonoBehaviour
{
    private CanvasGroup hpCanvas;
    public MonsterControl monster;
    public MonsterHP monsterHp;
    public float damage = 5f; // 한발당 받는 데미지

    void Start()
    {
        monsterHp = GameObject.Find("MonsterHPCanvas").GetComponent<MonsterHP>();
        monster = GameObject.Find("alien character01").GetComponent<MonsterControl>();
        hpCanvas = GameObject.Find("MonsterHPCanvas").GetComponent<CanvasGroup>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            hpCanvas.alpha = 1;
            monsterHp.currentHP -= damage; // 맞으면 체력 데미지만큼 감소
            monster.currentState = MonsterControl.CurrentState.hit; // 몬스터상태를 hit로 변경
        }
    }
}