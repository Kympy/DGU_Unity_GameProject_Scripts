﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed = 5f;    // 이동속도
    public float turnSpeed = 10f;  // 회전속도
    private Vector3 moveDirection; // 기본 달리기 벡터
    float horizontal;
    float vertical;
    bool check = false;

    Rigidbody playerRigidbody;
    Animator animator;
    CanvasGroup dead;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        dead = GetComponentInChildren<CanvasGroup>();
        Cursor.visible = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            check = !check;
            if (check == true)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                dead.alpha = 1;
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                dead.alpha = 0;
            }
        }
        if (Cursor.visible == false) // 커서가 숨김모드일때만 이동가능
        {
            horizontal = Input.GetAxisRaw("Horizontal");  // 이동키 입력
            vertical = Input.GetAxisRaw("Vertical");

            bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
            bool hasVerticalInput = !Mathf.Approximately(vertical, 0f); // 이동 여부 판별

            bool isWalking = hasHorizontalInput || hasVerticalInput;

            animator.SetBool("IsWalking", isWalking); // 이동 시작

            /*if (Input.GetKey(KeyCode.S))  // 
            {
                animator.SetBool("IsBack", true);
            }
            else animator.SetBool("IsBack", false);

            if (Input.GetKey(KeyCode.A))
            {
                animator.SetBool("IsLeft", true);
            }
            else animator.SetBool("IsLeft", false);

            if (Input.GetKey(KeyCode.D))
            {
                animator.SetBool("IsRight", true);
            }
            else animator.SetBool("IsRight", false);

            if (Input.GetKey(KeyCode.W))
            {
                animator.SetBool("IsFront", true);
            }
            else animator.SetBool("IsFront", false);*/  //블렌드 트리 사용
        }
    }
    void FixedUpdate()
    {
        if (Cursor.visible == false)
        {
            bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
            
            moveDirection = new Vector3(horizontal, 0f, vertical).normalized; // 이동벡터 정규화 // Rigidbody로 캐릭터 이동 실행
            playerRigidbody.MovePosition(playerRigidbody.position + transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime);

            //Vector3 desiredForward = Vector3.RotateTowards(transform.forward, moveDirection, turnSpeed * Time.deltaTime, 0f);
            //Quaternion targetRotate = Quaternion.LookRotation(desiredForward);



            /*if (hasHorizontalInput && Input.GetKey(KeyCode.W))  // 좌우 입력이 있고 전진 중일 경우 대각방향 회전 후 이동
            {
                //transform.Rotate(horizontal * Vector3.up * turnSpeed);  // 좌우 입력만 있을 경우 옆걸음으로 이동한다.
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotate, Time.deltaTime * turnSpeed); // 대각방향을 바라보고 달리기
            }
            else if (hasHorizontalInput && Input.GetKey(KeyCode.S)) //좌우 입력이 있고 후진 중일 경우 대각방향 회전 후 이동
            {
                //transform.Rotate(horizontal * Vector3.up * turnSpeed);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotate, Time.deltaTime * turnSpeed);
            }*/

        }
    }
}
