using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    private Animator door;
    void Start()
    {
        door = this.GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            door.SetBool("IsOpen", true);
        }
        else door.SetBool("IsOpen", false);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            door.SetBool("IsOpen", false);
        }
    }
}
