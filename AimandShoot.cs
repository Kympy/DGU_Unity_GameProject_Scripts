using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AimandShoot : MonoBehaviour
{
    bool cursorVisible = false; // 커서 보이기/숨기기 변수
    bool weapon = false; // 조준모드 활성/비활성 변수

    Animator animator;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // 기본 커서 중앙고정
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) // Tab 키를 이용한 커서 숨김/보이기
        {
            cursorVisible = !cursorVisible;
            if(cursorVisible)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

        if (!weapon && Input.GetKeyDown(KeyCode.Q))    // 조준모드 비활성화중인데 Q를 누르면 활성화 전환
        {
            animator.SetBool("IsAiming", true); 
            weapon = true;
        }
        else if (weapon && Input.GetKeyDown(KeyCode.Q)) // 조준모드 활성화중인데 Q를 누르면 비활성화 전환
        {
            animator.SetBool("IsAiming", false);
            weapon = false;
        }
        

        if (weapon && Input.GetKey(KeyCode.Mouse0)) // 조준모드 활성 & 좌클릭 시 공격
        {
            animator.SetBool("IsShooting", true);
        }
        else // 조준모드나 좌클릭 둘다 만족하지 않으면 공격 없음
        {
            animator.SetBool("IsShooting", false);
        }
    }
}
