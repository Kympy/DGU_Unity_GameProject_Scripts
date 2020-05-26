using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBulletBar : MonoBehaviour
{
    public Image bulletBar;
    public Shooting shoot;
    public float speed = 1f;

    private float currentBullet = 1000f;
    private float maxBullet = 1000f;
    private float bulletRate;
    void Start()
    {
        bulletBar = GetComponent<Image>();
        shoot = GameObject.Find("Player").GetComponent<Shooting>();
    }

    void Update()
    {
        if(shoot.isShoot == true)
        {
            currentBullet -= 1f;
            bulletRate = currentBullet / maxBullet;
            bulletBar.fillAmount = Mathf.Lerp(bulletBar.fillAmount, bulletRate, Time.deltaTime * speed);
        }
    }
}
