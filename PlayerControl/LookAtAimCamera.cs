using System.Collections;
using UnityEngine;
public class LookAtAimCamera : MonoBehaviour
{
    public Transform target; // 바라볼 타겟
    public Vector3 relativeVec; //물체에 대한 상대적인 벡터

    private Animator animator; // 애니메이션
    private Transform spine; // 아바타의 상체
    //private Vector3 chestDirection;

    bool aimMode = false;

    void Start () {
        animator = GetComponent<Animator>();
        spine = animator.GetBoneTransform(HumanBodyBones.Spine); // 상체값 가져오기 (허리 위)
    }
    void LateUpdate() 
    { 
        if(Input.GetKeyDown(KeyCode.Q)) // 좌클릭 눌리는 동안
        { 
            Debug.Log("바라보기");
            StartCoroutine(AimModeOn());
        }
        else if(Input.GetKeyDown(KeyCode.Q)) // 좌클릭을 떄면
        { 
            Debug.Log("해제");
            StartCoroutine(AimModeOff());
        }

        if(aimMode == true) //에임모드가 활성화 되면
        {
            //spine.rotation = Quaternion.Euler(mainCamera.transform.rotation.x);
           
            spine.LookAt(target.position); //플레이어의 상체부분이 타겟 위치 보기
            spine.rotation = spine.rotation * Quaternion.Euler(relativeVec);  // 타겟으로 회전
        } 
    }
    IEnumerator AimModeOn() // 에임모드가 켜지면 지정대기시간 이후 aimMode = true
    { 
        Debug.Log("조준");
        yield return new WaitForSeconds(0.07f);
        aimMode = true;
    }
    IEnumerator AimModeOff() //에임모드가 꺼지면 지정대기시간이후 aimMode = false
    { 
        yield return new WaitForSeconds(1.0f);
        aimMode = false; 
    } 
}