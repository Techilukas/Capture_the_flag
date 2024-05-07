using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;

public class shooting : NetworkBehaviour
{
    public Transform firePoint;
    public GameObject bullet_prefab;

    public float bulletForce = 20f;
    public float cooldown = 1f;

    float nextshot = 0;

    // Update is called once per frame
    void Update()
    {
        if (!IsOwner)
            return;


        if (Input.GetButtonDown("Fire1"))
        {
            if (nextshot > Time.time)
            {
                Debug.Log("Unable to shoot, on cooldown!");
                return;
            }

            shoot();
            nextshot = Time.time + cooldown;
        }

    }

    void shoot()
    {
        GameObject bullet = Instantiate(bullet_prefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}