using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AimandShoot : MonoBehaviour
{
    bool stopPlaying = false; // 커서 보이기/숨기기 변수
    public bool aimMode = false; // 조준모드 활성/비활성 변수
    PlayerControl playerControl;

    Animator animator;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // 기본 커서 중앙고정
        animator = GetComponent<Animator>();
        playerControl = GameObject.Find("Player").GetComponent<PlayerControl>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) // Tab 키를 이용한 게임 정지
        {
            stopPlaying = !stopPlaying;
            if(stopPlaying == true)
            {
                Time.timeScale = 0; // 게임 일시정지
            }
            else
            {
                Time.timeScale = 1; // 게임 다시 진행
            }
        }

        if (!aimMode && Input.GetKeyDown(KeyCode.Q))    // 조준모드 비활성화중인데 Q를 누르면 활성화 전환
        {
            playerControl.moveSpeed = 2.5f; // 조준 시 이동속도 느리게
            animator.SetBool("IsAiming", true);
            aimMode = true;
        }
        else if (aimMode && Input.GetKeyDown(KeyCode.Q)) // 조준모드 활성화중인데 Q를 누르면 비활성화 전환
        {
            playerControl.moveSpeed = 5f; // 조준해제 시 이동속도 복구
            animator.SetBool("IsAiming", false);
            aimMode = false;
        }
        

        if (stopPlaying == false && aimMode && Input.GetKey(KeyCode.Mouse0)) // 플레이중 & 조준모드 활성 & 좌클릭 시 공격
        {
            animator.SetBool("IsShooting", true);
        }
        else // 조준모드나 좌클릭 둘다 만족하지 않으면 공격 없음
        {
            animator.SetBool("IsShooting", false);
        }
    }
}
