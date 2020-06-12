using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWhenAttacked : MonoBehaviour
{
    public GameObject effect;
    public GameObject effectPosition;
    public float alienDamage = 50f; // 에일리언 공격 데미지
    public float zombieDamage = 25f; // 좀비 데미지

    private GameObject playingEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "AlienBullet") // 맞은게 에일리언의 총알이라면 총알 삭제
        {
            Destroy(other.gameObject); // 총알 삭제
            PlayerHPBar.currentHP -= alienDamage; // 받은 데미지 만큼 체력감소

            playingEffect = Instantiate(effect, effectPosition.transform.position, effectPosition.transform.rotation);
            Destroy(playingEffect, 1f); // 피격 이펙트

            /*if (PlayerHPBar.currentHP == 0f)
            {
                PlayerHPBar.currentHP = 0f;
            }*/
        }
        else if (other.gameObject.tag == "ZombieArm")
        {
            PlayerHPBar.currentHP -= zombieDamage; // 받은 데미지 만큼 체력감소
            playingEffect = Instantiate(effect, effectPosition.transform.position, effectPosition.transform.rotation);
            Destroy(playingEffect, 1f); // 피격 이펙트
        }
    }

}
