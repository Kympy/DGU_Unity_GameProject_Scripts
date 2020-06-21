using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public class ZombieControl : MonoBehaviour
{
    public enum CurrentState { idle, trace, attack, dead};
    public CurrentState currentState = CurrentState.idle; // 몬스터 상태 정의, 현재상태는 idle
    public float traceDistance = 10f; // 몬스터 추적거리
    public float attackDistance = 2f; // 몬스터 공격거리
    public bool isDead = false;
    public GameObject battery;
    public GameObject lazer;

    private ZombieHP zombieHP;

    Transform monsterTransform;
    Transform playerTransform;
    NavMeshAgent navAgent;
    Animator alienAnimator;

    private float timer;
    private float deadTime = 4f; // 죽는 시간

    void Start()
    {
        monsterTransform = this.gameObject.GetComponent<Transform>();
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        navAgent = this.gameObject.GetComponent<NavMeshAgent>();
        alienAnimator = GetComponent<Animator>();
        zombieHP = this.GetComponentInChildren<ZombieHP>();

        navAgent.destination = playerTransform.position + attackDistance * Vector3.forward; //플레이어를 목적지로 설정

        int randNum = Random.Range(1, 4);
        if (randNum == 1) monsterTransform.position = (monsterTransform.transform.position + 3 * Vector3.forward);
        else if (randNum == 2) monsterTransform.transform.position = (monsterTransform.transform.position + 3 * Vector3.back);
        else if (randNum == 3) monsterTransform.transform.position = (monsterTransform.transform.position + 3 * Vector3.right);
        else monsterTransform.transform.position = (monsterTransform.transform.position + 3 * Vector3.left);

        StartCoroutine(this.CheckState()); // 몬스터 상태체크
        StartCoroutine(this.CheckStateForAnimation()); // 상태에 따른 애니메이션
    }
    void Update()
    {
        if (isDead == false && currentState == CurrentState.attack || currentState == CurrentState.trace) // 추적, 공격중이라면 플레이어를 바라본다
        {
            this.transform.LookAt(playerTransform);
        }
        if (isDead == true)
        {
            alienAnimator.SetBool("IsDead", true);
            alienAnimator.SetBool("IsTrace", false);
            alienAnimator.SetBool("IsAttack", false);
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
            float betweenDistance = Vector3.Distance(playerTransform.position, monsterTransform.position); // 몬스터와 플레이어 사이 거리
            if (betweenDistance <= attackDistance)
            {
                currentState = CurrentState.attack; // 사정거리 안일때 공격
            }
            else if (betweenDistance < traceDistance)
            {
                currentState = CurrentState.trace; // 추적거리 안이면 추적
            }
            else
            {
                currentState = CurrentState.idle;
            }
            if (zombieHP.currentHP == 0f)
            {
                isDead = true;
                SpawnMonster.currentMonsterCount -= 1;
                int num = Random.Range(1, 5);       // 40% 확률 템 드랍
                yield return new WaitForSeconds(4f);
                if (num == 1) Instantiate(battery, this.transform.position, Quaternion.identity);
                else if (num == 2) Instantiate(lazer, this.transform.position, Quaternion.identity);

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
                    alienAnimator.SetBool("IsTrace", false);
                    alienAnimator.SetBool("IsAttack", false);
                    break;
                case CurrentState.trace:
                    navAgent.destination = playerTransform.position + attackDistance * Vector3.forward;
                    navAgent.isStopped = false;
                    alienAnimator.SetBool("IsTrace", true);
                    alienAnimator.SetBool("IsAttack", false);
                    break;
                case CurrentState.attack:
                    alienAnimator.SetBool("IsAttack", true);
                    break;
                default:
                    break;
            }
            yield return null;
        }
    }
}
