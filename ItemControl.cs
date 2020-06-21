using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemControl : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(this.gameObject.name == "Battery" && other.gameObject.tag == "Player")
        {
            BSlot.battery += 1;
            Destroy(transform.parent.gameObject);
        }
        else if (this.gameObject.name == "LazerBattery" && other.gameObject.tag == "Player")
        {
            LSlot.lazer += 1;
            Destroy(transform.parent.gameObject);
        }
    }
}
