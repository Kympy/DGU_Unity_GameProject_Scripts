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
    public GameObject spawnPoint;

    private float timer;
    private MonsterHP bosshp;
    Animator bossAni;


    private void Start()
    {

        boss = this.GetComponentInParent<BossControl>();
        bosshp = GameObject.Find("BossHPCanvas01").GetComponent<MonsterHP>();
        bossAni = this.GetComponentInParent<Animator>();
        spawnPoint.gameObject.SetActive(false);
        timer = 0f;
        //this.gameObject.SetActive(false);

    }
    private void Update()
    {
        if (bossAni.GetBool("IsGuard") == true && boss.isGuard == true)
        {
            //this.gameObject.SetActive(true);
            timer += Time.deltaTime;
            if (timer > 2f) lazer.gameObject.SetActive(true);
            if (timer > 6f)
            {
                lazer.gameObject.SetActive(false);
                //this.gameObject.SetActive(false);
                boss.isGuard = false;
                bosshp.currentHP -= 5f;
                timer = 0f;
            } 
        }
        else if(bossAni.GetBool("IsGuard") == true && boss.isSpawn == true)
        {
            spawnPoint.gameObject.SetActive(true);
            timer += Time.deltaTime;
            if(timer > 6f)
            {
                spawnPoint.gameObject.SetActive(false);
                boss.isSpawn = false;
                bosshp.currentHP -= 5f;
                timer = 0f;
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
