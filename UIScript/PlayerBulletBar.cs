using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBulletBar : MonoBehaviour
{
    public Image bulletBar;
    public Shooting shoot;

    private static float currentBullet = 4000f;
    private float maxBullet = 4000f;
    private float bulletRate;
    private float speed = 3f;
    private Animator animator;
    private float timer;
    //private bool go = false;
    void Start()
    {
        bulletBar = GetComponent<Image>();
        shoot = GameObject.Find("Player").GetComponent<Shooting>();
        animator = GameObject.Find("Player").GetComponent<Animator>();
        currentBullet = 4000f;
        bulletBar.color = new Color(73 / 255f, 238 / 255f, 112 / 255f); // 초기 바 색상

        timer = 0f;
    }

    void Update()
    {

        bulletRate = currentBullet / maxBullet; // 잔탄 비율
        bulletBar.fillAmount = Mathf.Lerp(bulletBar.fillAmount, bulletRate, Time.deltaTime * speed);

        // 재장전
        if (Input.GetKeyDown(KeyCode.R) && LSlot.lazer != 0 && animator.GetBool("IsAiming"))
        {
                currentBullet += 1000f;
                LSlot.lazer -= 1;
                animator.SetBool("IsReload", true); // 재장전 애니메이션
        }
        else
        {
            timer += Time.deltaTime;
            if (timer > 3f)
            {
                animator.SetBool("IsReload", false);
                timer = 0f;
            }
            
        }

        // 사격
        if (shoot.isShoot == true)
        {
            currentBullet -= 1f; // 총알 한발씩 소모
            if (currentBullet <= 0f)
            {
                currentBullet = 0f;
                shoot.bulletIslack = true; // 총알이 부족하면 트루 반환 및 사격 불가
            }
            else
            {
                shoot.bulletIslack = false;
            }
        }

        // 총알게이지에 따라 색깔변경
        if (currentBullet > 4000f) currentBullet = maxBullet;
        if (currentBullet <= 4000f)
        {
            bulletBar.color = new Color(73 / 255f, 238 / 255f, 112 / 255f);
        }
        if (currentBullet < 2000f)
        {
            bulletBar.color = new Color(243 / 255f, 125 / 255f, 0);
        }
        if (currentBullet < 800f)
        {
            bulletBar.color = Color.red;
        }


    }
}
