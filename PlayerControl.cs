using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed = 3f;    // 이동속도
    public float turnSpeed = 1.5f;  // 회전속도
    private Vector3 moveDirection; // 기본 달리기 벡터

    Rigidbody playerRigidbody;
    Animator animator;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        Cursor.visible = false;
    }
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");  // 이동키 입력
        float vertical = Input.GetAxisRaw("Vertical");

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f); // 이동 여부 판별

        bool isWalking = hasHorizontalInput || hasVerticalInput;

        animator.SetBool("IsWalking", isWalking); // 이동 시작

        if(Input.GetKey(KeyCode.S))
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
        else animator.SetBool("IsFront", false);
        //desiredForward.Set(horizontal, 0f, vertical);
        //desiredForward = desiredForward.normalized;
        //desiredForward = Vector3.RotateTowards(transform.forward, moveDirection, turnSpeed * Time.deltaTime, 0f);
        //rotation = Quaternion.LookRotation(desiredForward);  
    }
    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical"); // 키입력

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);

        moveDirection = new Vector3(horizontal, 0f, vertical).normalized; // 이동벡터 정규화
        // Rigidbody로 캐릭터 이동 실행
        playerRigidbody.MovePosition(playerRigidbody.position + transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime);

        if (hasHorizontalInput && Input.GetKey(KeyCode.W))  // 좌우 입력이 있고 전진 중일 경우 대각방향 회전이동
        {
            transform.Rotate(horizontal * Vector3.up * turnSpeed);  // 좌우 입력만 있을 경우 옆걸음으로 이동한다.
        }
        else if (hasHorizontalInput && Input.GetKey(KeyCode.S)) //좌우 입력이 있고 후진 중일 경우 대각방향 회전이동
        {
            transform.Rotate(horizontal * Vector3.up * turnSpeed);
        }
        
    }
}
