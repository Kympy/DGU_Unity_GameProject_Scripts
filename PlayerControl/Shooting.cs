using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePosition;
    public AimandShoot aimAndShoot;
    public bool isShoot = false; // bullet bar 조정을 위한 값(잔탄 0 시 사격 불가)
    public float attackCoolTime = 0.2f; // 발사 쿨타임
    public bool bulletIslack = false;

    private float timer;
    
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
        if (aimAndShoot.aimMode == true && Input.GetMouseButton(0) == true && bulletIslack == false) // 조준모드 & 클릭 & 총알유무
        {
            Instantiate(bullet, firePosition.transform.position, firePosition.transform.rotation); // 총알복사후 발사
            isShoot = true;
        }
        else
        {
            isShoot = false;
        }
    }
}
