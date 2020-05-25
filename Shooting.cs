using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePosition;
    public AimandShoot aimAndShoot;

    private float timer;
    public float attackCoolTime = 0.2f; // 발사 쿨타임
    void Start()
    {
        aimAndShoot = GameObject.Find("Player").GetComponent<AimandShoot>();
        timer = 0f;
    }

    void Update()
    {
        timer += Time.deltaTime; // 타이머설정

        if(timer >= attackCoolTime) // 쿨타임보다 타이머가 커지면 발사
        {
            Attack();
            timer = 0;
        }      
    }
    private void Attack()
    {
        if (aimAndShoot.aimMode == true && Input.GetMouseButton(0) == true)
        {
            Instantiate(bullet, firePosition.transform.position, firePosition.transform.rotation); // 총알복사후 발사
        }
    }
}
