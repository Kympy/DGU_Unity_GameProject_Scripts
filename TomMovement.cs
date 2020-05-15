using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomMovement : MonoBehaviour
{
    Vector3 movement;
    Quaternion rotation = Quaternion.identity;
    Animator animator;
    Rigidbody playerRigidbody;

    public float moveSpeed = 1f;
    public float turnSpeed = 10f;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

    }
    private void OnAnimatorMove()
    {
        playerRigidbody.MovePosition(playerRigidbody.position + movement);
        playerRigidbody.MoveRotation(rotation);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        movement = new Vector3(horizontal, 0f, vertical).normalized * moveSpeed * Time.deltaTime;

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);

        bool isWalking = hasHorizontalInput || hasVerticalInput;

        animator.SetBool("IsWalking", isWalking);


        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, movement, turnSpeed * Time.deltaTime, 0f);
        rotation = Quaternion.LookRotation(desiredForward);
    }
}
