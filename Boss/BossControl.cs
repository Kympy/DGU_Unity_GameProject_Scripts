using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class BossControl : MonoBehaviour
{
    public enum CurrentState { idle, trace, attack, guard, spawn, dead };
    public CurrentState currentState = CurrentState.idle; // 몬스터 상태 정의, 현재상태는 idle
    public float traceDistance = 27f; // 보스 추적거리
    public float attackDistance = 8f; // 몬스터 공격거리
    public bool isDead = false;
    public bool isGuard = false;
    public bool isSpawn = false;
    public GameObject portal;

    private MonsterHP bossHP;

    Transform bossTransform;
    Transform playerTransform;
    NavMeshAgent navAgent;
    Animator bossAnimator;
    GameObject shield;

    private float timer;
    private float deadTime = 4f; // 죽는 시간

    void Start()
    {
        bossTransform = this.gameObject.GetComponent<Transform>();
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        navAgent = this.gameObject.GetComponent<NavMeshAgent>();
        bossAnimator = GetComponent<Animator>();
        bossHP = this.GetComponentInChildren<MonsterHP>();
        shield = transform.Find("Shield").gameObject;

        navAgent.destination = playerTransform.position + attackDistance * Vector3.forward; //플레이어를 목적지로 설정

        StartCoroutine(this.CheckState()); // 몬스터 상태체크
        StartCoroutine(this.CheckStateForAnimation()); // 상태에 따른 애니메이션
    }
    void Update()
    {
        if (isDead == false && currentState == CurrentState.attack) // 공격중이라면 플레이어를 바라본다
        {
            this.transform.LookAt(playerTransform);
        }
        if (isDead == true)
        {
            bossAnimator.SetBool("IsDead", true);
            bossAnimator.SetBool("IsTrace", false);
            bossAnimator.SetBool("IsAttack", false);
            timer += Time.deltaTime;
            if (timer >= deadTime) // 죽는 모션이 끝나면 오브젝트 삭제
            {
                Destroy(this.gameObject);
            }
        }
    }
    IEnumerator CheckState()
    {
        while (!isDead) // 몬스터가 죽을때까지
        {
            yield return new WaitForSeconds(0.2f);
            float betweenDistance = Vector3.Distance(playerTransform.position, bossTransform.position); // 몬스터와 플레이어 사이 거리
            if (isSpawn == false && isGuard == false && betweenDistance <= attackDistance)
            {
                currentState = CurrentState.attack; // 사정거리 안일때 공격
            }
            else if (isSpawn == false && isGuard == false && betweenDistance < traceDistance)
            {
                currentState = CurrentState.trace; // 추적거리 안이면 추적
            }
            else
            {
                currentState = CurrentState.idle;
            }

            if (bossHP.currentHP == 165f || bossHP.currentHP == 120f || bossHP.currentHP == 70f || bossHP.currentHP == 20f)
            {
                shield.SetActive(true);
                currentState = CurrentState.guard; // 조건 만족시 가드
                isGuard = true;
            }
            else if (bossHP.currentHP == 100f)
            {
                shield.SetActive(true);
                currentState = CurrentState.spawn; // 조건 만족시 몬스터 소환
                isSpawn = true;
            }

            if (bossHP.currentHP == 0f)
            {
                isDead = true;
                portal.SetActive(true);
            }

        }

    }
    IEnumerator CheckStateForAnimation()
    {
        while (!isDead)
        {
            switch (currentState)
            {
                case CurrentState.idle:
                    navAgent.isStopped = true;
                    bossAnimator.SetBool("IsTrace", false);
                    bossAnimator.SetBool("IsAttack", false);
                    bossAnimator.SetBool("IsGuard", false);
                    shield.SetActive(false);
                    break;
                case CurrentState.trace:
                    navAgent.destination = playerTransform.position + attackDistance * Vector3.forward;
                    navAgent.isStopped = false;
                    bossAnimator.SetBool("IsTrace", true);
                    bossAnimator.SetBool("IsAttack", false);
                    bossAnimator.SetBool("IsGuard", false);
                    shield.SetActive(false);
                    break;
                case CurrentState.attack:
                    navAgent.destination = bossTransform.position;
                    bossAnimator.SetBool("IsAttack", true);
                    bossAnimator.SetBool("IsTrace", false);
                    bossAnimator.SetBool("IsGuard", false);
                    shield.SetActive(false);
                    break;
                case CurrentState.guard:
                    navAgent.destination = bossTransform.position;
                    bossAnimator.SetBool("IsGuard", true);
                    bossAnimator.SetBool("IsAttack", false);
                    bossAnimator.SetBool("IsTrace", false);
                    
                    break;
                case CurrentState.spawn:
                    navAgent.destination = bossTransform.position;
                    bossAnimator.SetBool("IsGuard", true);
                    bossAnimator.SetBool("IsAttack", false);
                    bossAnimator.SetBool("IsTrace", false);
                    
                    break;
                default:
                    break;
            }
            yield return null;
        }
    }
}
