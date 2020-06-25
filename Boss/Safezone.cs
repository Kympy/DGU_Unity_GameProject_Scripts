using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safezone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "AlienBullet")
        {
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
        }
    }
}
