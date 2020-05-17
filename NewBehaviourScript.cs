/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class NewBehaviourScript : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float turnSpeed = 10f;
    float horizontal;
    float vertical;
    private Vector3 moveDirection;
    bool hasVerticalInput;
    bool hasHorizontalInput;

    Rigidbody playerRigidbody;
    Animator animator;
    
    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        moveDirection = (Vector3.forward * vertical) + (Vector3.right * horizontal);


        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);

        bool isWalking = hasHorizontalInput || hasVerticalInput;

        animator.SetBool("IsWalking", isWalking);

    }
    void FixedUpdate()
    {
        Move();
        Turn();
    }
    void Move()
    {
        moveDirection.Set(horizontal, 0f, vertical);
        moveDirection = moveDirection.normalized * moveSpeed * Time.deltaTime;

        playerRigidbody.MovePosition(transform.position + moveDirection);
    }
    void Turn()
    {
        if (horizontal == 0f || vertical == 0f)
           return;
        Quaternion newRotation = Quaternion.LookRotation(moveDirection);
        playerRigidbody.rotation = Quaternion.Slerp(playerRigidbody.rotation, newRotation, turnSpeed * Time.deltaTime);
    }
}*/
