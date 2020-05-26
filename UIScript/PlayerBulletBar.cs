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

    private float currentBullet;
    private float maxBullet = 5000f;
    private float bulletRate;
    private float speed = 3f;
    void Start()
    {
        bulletBar = GetComponent<Image>();
        shoot = GameObject.Find("Player").GetComponent<Shooting>();
        bulletBar.color = new Color(73 / 255f, 238 / 255f, 112 / 255f); // 초기 바 색상
        currentBullet = maxBullet; // 초기 장탄수 설정
    }

    void Update()
    {

        bulletRate = currentBullet / maxBullet; // 잔탄 비율
        bulletBar.fillAmount = Mathf.Lerp(bulletBar.fillAmount, bulletRate, Time.deltaTime * speed);

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
        if (currentBullet <= 1000f)
        {
            bulletBar.color = new Color(73 / 255f, 238 / 255f, 112 / 255f);
        }
        if (currentBullet < 500f)
        {
            bulletBar.color = new Color(243 / 255f, 125 / 255f, 0);
        }
        if (currentBullet < 150f)
        {
            bulletBar.color = Color.red;
        }
    }
}
