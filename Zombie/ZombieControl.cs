﻿using System.Collections;
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
    public float attackDistance = 1.5f; // 몬스터 공격거리
    public static bool isDead = false; // MonsterHP 에서 이 값을 통해 사망 애니메이션 재생

    Transform monsterTransform;
    Transform playerTransform;
    NavMeshAgent navAgent;
    Animator alienAnimator;

    private float timer;
    private float deadTime = 4f; // 죽는 시간
    private SpawnMonster spawn; // 스폰 관리 변수

    void Start()
    {
        monsterTransform = this.gameObject.GetComponent<Transform>();
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        navAgent = this.gameObject.GetComponent<NavMeshAgent>();
        alienAnimator = GetComponent<Animator>();
        spawn = GetComponent<SpawnMonster>();

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
        if (currentState == CurrentState.attack || currentState == CurrentState.trace) // 추적, 공격중이라면 플레이어를 바라본다
        {
            this.transform.LookAt(playerTransform);
        }
        if (isDead == true)
        {
            alienAnimator.SetBool("IsDead", true);
            alienAnimator.SetBool("IsTrace", false);
            alienAnimator.SetBool("IsAttack", false);

            if (isDead == true)
            {
                timer += Time.deltaTime;
                if (timer >= deadTime) // 죽는 모션이 끝나면 오브젝트 삭제
                {
                    Destroy(this.gameObject);
                }
            }
            else isDead = false;
        }
    }
    IEnumerator CheckState()
    {
        while (!isDead) // 몬스터가 죽을때까지
        {
            yield return new WaitForSeconds(0.2f);
            float betweenDistance = Vector3.Distance(playerTransform.position,
                monsterTransform.position); // 몬스터와 플레이어 사이 거리
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
            if (isDead == true)
            {
                spawn.currentMonsterCount -= 1;
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
            }
            yield return null;
        }
    }
}
