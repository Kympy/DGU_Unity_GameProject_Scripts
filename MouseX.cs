using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseX : MonoBehaviour
{
    Vector3 sight; // 마우스 x축에 따라 움직이는 벡터
    public float turnSpeed = 200f;


    void Update()
    {
        if (Cursor.visible == false)
        {
            sight = new Vector3(0f, Input.GetAxis("Mouse X"), 0f);
            transform.Rotate(sight * turnSpeed * Time.deltaTime);    // 마우스 x축에 따라 캐릭터 및 시야 좌우 회전
        }
    }
}
