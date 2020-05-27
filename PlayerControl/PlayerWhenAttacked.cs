using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWhenAttacked : MonoBehaviour
{
    public GameObject effect;
    public GameObject effectPosition;
    public float damage = 50f;

    private GameObject playingEffect;
    private PlayerHPBar hpBar;

    // Start is called before the first frame update
    private void Start()
    {
        hpBar = GameObject.Find("HPBar").GetComponent<PlayerHPBar>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            hpBar.currentHP -= damage;

            playingEffect = Instantiate(effect, effectPosition.transform.position, effectPosition.transform.rotation);
            Destroy(playingEffect, 1f);

            if (hpBar.currentHP == 0f)
            {
                hpBar.currentHP = 0f;
            }
        }
    }

}
