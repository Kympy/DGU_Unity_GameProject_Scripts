﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhenAttacked : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
        }
    }
}
