using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float shootSpeed = 1f;
    void Update()
    {
        transform.Translate(Vector3.up * shootSpeed); // up으로 shootSpeed만큼 매프레임이동
    }
}
