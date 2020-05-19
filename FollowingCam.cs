using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FollowingCam : MonoBehaviour
{   
    public Transform target; //추적할 대상
    public float distance = 3.5f;  
    public float xSpeed = 150.0f; //카메라 회전 속도
    public float ySpeed = 100.0f;
   
    private float x = 40.0f;//카메라 초기 위치
    private float y = 0.0f;

    public float yMinLimit = -20f; //y값 제한 (위 아래 제한)
    public float yMaxLimit = 50f;
    float ClampAngle(float angle, float min, float max) //앵글의 최소,최대 제한
    {
        if (angle < -360)
        {
            angle += 360;
        }
        if (angle > 360)
        {
            angle -= 360;
        }
        return Mathf.Clamp(angle, min, max);
    }
    void Start()
    {
        Vector3 angles = transform.eulerAngles;

        x = angles.y;
        y = angles.x;
    }
    void Update()
    {
        if (Cursor.visible == false)
        {
            x += Input.GetAxis("Mouse X") * xSpeed * 0.015f; //카메라 회전속도 계산
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.015f;

            //앵글값 정하기(y값 제한)
            y = ClampAngle(y, yMinLimit, yMaxLimit);

            //카메라 위치 변화 계산
            Quaternion rotation = Quaternion.Euler(y, x, 0);
            Vector3 position = rotation * new Vector3(1.5f, 0.9f, -distance) + target.position + new Vector3(0.0f, 0, 0.0f); //위치벡터

            transform.rotation = rotation;
            target.rotation = Quaternion.Euler(0, x, 0);
            transform.position = position;
        }
    }
}