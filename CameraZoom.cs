using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float zoomSpeed = 10f;
    public float rotateRate = 0.95f; // 각도 최소최대 6 ~ 28, 필드오브뷰 최소최대 33~48
    public Transform targetPlayer;

    private Camera mainCamera;
   
    void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

void Update()
    {
        Zoom();
    }

    private void Zoom()
    {
        float distance = Input.GetAxis("Mouse ScrollWheel") * -1 * zoomSpeed;
            
            if (mainCamera.fieldOfView <= 48f && distance < 0)
            {
                Vector3 zoomRotateMinus = new Vector3(mainCamera.transform.rotation.x - rotateRate, 0f, 0f);
                mainCamera.fieldOfView += distance;
                mainCamera.transform.Rotate(zoomRotateMinus);

                if (mainCamera.fieldOfView < 36f)
                {
                    mainCamera.fieldOfView = 36f;
                    mainCamera.transform.localRotation = Quaternion.Euler(14, 0, 0);
                }       
            }
            else if (mainCamera.fieldOfView >= 33f && distance > 0)
            {
                Vector3 zoomRotatePlus = new Vector3(mainCamera.transform.rotation.x + rotateRate, 0f, 0f);
                mainCamera.fieldOfView += distance;
                mainCamera.transform.Rotate(zoomRotatePlus);
                
                if (mainCamera.fieldOfView > 48f)
                {
                    mainCamera.fieldOfView = 48f;
                    mainCamera.transform.localRotation = Quaternion.Euler(28, 0, 0);
                }
            }
        }
}