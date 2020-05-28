using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWhenAttacked : MonoBehaviour
{
    public GameObject effect;
    public GameObject effectPosition;
    public float alienDamage = 50f; // 에일리언 공격 데미지

    private GameObject playingEffect;
    private PlayerHPBar hpBar;

    // Start is called before the first frame update
    private void Start()
    {
        hpBar = GameObject.Find("HPBar").GetComponent<PlayerHPBar>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "AlienBullet") // 맞은게 에일리언의 총알이라면 총알 삭제
        {
            Destroy(other.gameObject);
            hpBar.currentHP -= alienDamage; // 받은 데미지 만큼 체력감소

            playingEffect = Instantiate(effect, effectPosition.transform.position, effectPosition.transform.rotation);
            Destroy(playingEffect, 1f); // 피격 이펙트

            if (hpBar.currentHP == 0f)
            {
                hpBar.currentHP = 0f;
            }
        }
    }

}
