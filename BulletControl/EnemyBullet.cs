using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private float timer;
    private float remainTime = 1.5f; //총알 지속시간
    public float shootSpeed = 1f;
    void Update()
    {
        transform.Translate(Vector3.up * shootSpeed); // up으로 shootSpeed만큼 매프레임이동
        timer += Time.deltaTime;
        if (timer >= remainTime)
        {
            Destroy(this.gameObject); // 총알 지속시간 보다 시간이 흐를경우 총알 오브젝트 삭제
        }
    }
}
