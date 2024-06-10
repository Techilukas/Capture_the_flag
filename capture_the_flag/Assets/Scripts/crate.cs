using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Networking;
using UnityEngine;

public class crate : NetworkBehaviour
{
    public GameObject banana_prefab;
    public float max_health;
    float health;

    private void Start()
    {
        health = max_health;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collider = collision.gameObject;

        if(collider.tag == "bullet")
        {
            bullet bullet = collider.GetComponent<bullet>();
            take_Damage(bullet.damage);
        }
    }

    public void take_Damage(float amount)
    {
        health -= amount;

        if (health <= 0) dienetworkRPC();
    }

    [Rpc(SendTo.Everyone)]
    void dienetworkRPC()
    {
        die();
    }

    void die()
    {
        Destroy(gameObject);
        Instantiate(banana_prefab, transform.position, Quaternion.identity);
    }
}
