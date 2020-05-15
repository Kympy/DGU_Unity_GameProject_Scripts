using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseY : MonoBehaviour
{
    Vector3 sight;

    public float turnSpeed = 100f;

    void Update()
    {
        if (Cursor.visible == false)
        {
            sight = new Vector3(-Input.GetAxis("Mouse Y"), 0, 0); // 마우스 y축에 따라 캐릭터 및 시야 상하회전
            transform.Rotate(sight * turnSpeed * Time.deltaTime);
        }
    }
}
