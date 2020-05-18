using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightControl : MonoBehaviour
{
    Vector3 xSight;
    Vector3 ySight;

    public float xSensitivity = 100f;
    public float ySensitivity = 100f;

    public GameObject player;

    void Update()
    {
        if (Cursor.visible == false)
        {
            xSight = new Vector3(0f, Input.GetAxis("Mouse X"), 0f);
            player.transform.Rotate(xSight * xSensitivity * Time.smoothDeltaTime);    // 마우스 x축에 따라 캐릭터 및 시야 좌우 회전

            /*ySight = new Vector3(-Input.GetAxis("Mouse Y"), 0, 0); // 마우스 y축에 따라 캐릭터 및 시야 상하회전
            transform.Rotate(ySight * yTurnSpeed * Time.smoothDeltaTime);*/

            ySight = new Vector3(-Input.GetAxis("Mouse Y"), 0, 0);
            transform.Rotate(ySight * ySensitivity * Time.smoothDeltaTime);
            //Debug.Log(ySight.x);          
        }
    }
}
