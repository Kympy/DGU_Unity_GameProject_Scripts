using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithBullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Bullet")
        {
            Destroy(collision.gameObject); // 충돌시 총알 태그 체크 후 삭제
        }
    }
}
