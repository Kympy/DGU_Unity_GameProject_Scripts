using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterControl : MonoBehaviour
{
    public enum CurrentState { idle, trace, attack, dead };
    public CurrentState currentState = CurrentState.idle;
    // 몬스터 상태 정의, 현재상태는 idle
    public float traceDistance = 15f; // 몬스터 추적거리
    public float attackDistance = 7f; // 몬스터 공격거리

    bool isDead = false;

    Transform monsterTransform;
    Transform playerTransform;
    NavMeshAgent navAgent;
    Animator alienAnimator;
    void Start()
    {
        monsterTransform = this.gameObject.GetComponent<Transform>();
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        navAgent = this.gameObject.GetComponent<NavMeshAgent>();
        navAgent.destination = playerTransform.position +  attackDistance * Vector3.back; //플레이어를 목적지로 설정
        alienAnimator = GetComponent<Animator>();

        StartCoroutine(this.CheckState());
        StartCoroutine(this.CheckStateForAnimation());
    }
    IEnumerator CheckState()
    {
        while(!isDead) // 몬스터가 죽을때까지
        {
            yield return new WaitForSeconds(0.2f);
            float betweenDistance = Vector3.Distance(playerTransform.position, 
                monsterTransform.position); // 몬스터와 플레이어 사이 거리
            if(betweenDistance <= attackDistance)
            {
                currentState = CurrentState.attack; // 사정거리 안일때 공격
            }
            else if(betweenDistance <= traceDistance)
            {
                currentState = CurrentState.trace; // 추적거리 안이면 추적
            }
            else
            {
                currentState = CurrentState.idle;
            }
        }
    }
    IEnumerator CheckStateForAnimation()
    {
        while(!isDead)
        {
            switch(currentState)
            {
                case CurrentState.idle:
                    navAgent.isStopped = true;
                    alienAnimator.SetBool("IsTrace", false);
                    break;
                case CurrentState.trace:
                    navAgent.destination = playerTransform.position + attackDistance * Vector3.back;
                    navAgent.isStopped = false;
                    alienAnimator.SetBool("IsTrace", true);
                    break;
                case CurrentState.attack:
                    break;
            }
            yield return null;
        }
    }

}
