using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private GameObject sparkEffect;
    private BossControl boss;

    public GameObject effect;
    public GameObject lazer;
    public Transform effectPosition;

    private float timer;
    private MonsterHP bosshp;


    private void Start()
    {
        boss = this.GetComponentInParent<BossControl>();
        bosshp = this.GetComponent<MonsterHP>();
    }
    private void Update()
    {
        if (boss.currentState == BossControl.CurrentState.guard)
        {
            boss.isGuard = true;
            this.gameObject.SetActive(true);
            timer += Time.deltaTime;
            if (timer > 2f) lazer.gameObject.SetActive(true);
            if (timer > 6f)
            {
                lazer.gameObject.SetActive(false);
                this.gameObject.SetActive(false);
                boss.isGuard = false;
            } 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
        }
        sparkEffect = Instantiate(effect, effectPosition.transform.position, effectPosition.transform.rotation);
        Destroy(sparkEffect, 1f); // 이펙트 6초 재생후 삭제

    }
}
