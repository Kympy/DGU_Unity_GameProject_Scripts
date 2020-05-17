/*using System.Collections;
using UnityEngine;

public class FollowingCam : MonoBehaviour
{
    public Transform targetPlayer;
    public float distance = 10f;
    public float height = 5f;
    public float smoothRotate = 5f;

    private Transform cameraSelf;
    void Start()
    {
        cameraSelf = GetComponent<Transform>();
    }


    void LateUpdate()
    {
        float yAngle = Mathf.LerpAngle(cameraSelf.eulerAngles.y, targetPlayer.eulerAngles.y,
            smoothRotate * Time.deltaTime);
        Quaternion yRotation = Quaternion.Euler(0f, yAngle, 0f);

        cameraSelf.position = targetPlayer.position - (yRotation * Vector3.forward * distance)
            + (Vector3.up * height);

        cameraSelf.LookAt(targetPlayer);
    }
    
}*/
