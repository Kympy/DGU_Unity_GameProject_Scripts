using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePosition; // 몬스터의 총알 사격 위치
    private Animator animator;

    public float attackCoolTime = 1.5f; // 몬스터의 공격 발사 쿨타임

    private float timer;

    void Start()
    {
        timer = 0f;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (animator.GetBool("IsAttack"))
        {
            timer += Time.deltaTime; // 타이머설정

            if (timer >= attackCoolTime) // 쿨타임보다 타이머가 커지고 공격중이면 발사
            {
                Attack();
                timer = 0f;
            }
        }
    }
    private void Attack()
    {
        Instantiate(bullet, firePosition.transform.position, firePosition.transform.rotation); // 총알복사후 발사
    }
}
