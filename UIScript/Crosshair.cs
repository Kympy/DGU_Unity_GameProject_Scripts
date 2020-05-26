using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    Animator animator; // 크로스헤어 애니메이터
    Animator animator2; // 플레이어의 애니메이터

    public GameObject player;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator2 = player.GetComponent<Animator>();
    }
    void Update()
    {

        if (animator2.GetFloat("HorizontalVelocity") > 0f || animator2.GetFloat("VerticalVelocity") > 0f)
        { 
            animator.SetBool("IsWalk", true); // 이동이 있으면, 조준원이 커진다.
        }
        else { animator.SetBool("IsWalk", false); }
    }
}
