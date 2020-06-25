using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemControl : MonoBehaviour
{
    private AudioSource drop;
    private void Start()
    {
        drop = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if(this.gameObject.name == "Battery" && other.gameObject.tag == "Player")
        {
            BSlot.battery += 1;
            drop.Play();
            Destroy(transform.parent.gameObject, 0.3f);
        }
        else if (this.gameObject.name == "LazerBattery" && other.gameObject.tag == "Player")
        {
            LSlot.lazer += 1;
            drop.Play();
            Destroy(transform.parent.gameObject, 0.3f);
        }
    }
}
