using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePosition;
    private Animator animator;

    public float attackCoolTime = 1.5f; // 발사 쿨타임
    public bool bulletIslack = false;

    private float timer;

    void Start()
    {
        timer = 0f;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        timer += Time.deltaTime; // 타이머설정

        if (timer >= attackCoolTime && animator.GetBool("IsAttack")) // 쿨타임보다 타이머가 커지고 공격중이면 발사
        {
            Attack();
            timer = 0f;
        }
    }
    private void Attack()
    {
        Instantiate(bullet, firePosition.transform.position, firePosition.transform.rotation); // 총알복사후 발사
    }
}
