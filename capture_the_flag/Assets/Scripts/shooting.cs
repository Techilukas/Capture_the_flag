using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;

public class shooting : NetworkBehaviour
{
    public Transform firePointRotator;
    public Transform firePoint;
    public GameObject bullet_prefab;

    Camera cam;
    float angle;

    public float bulletForce = 20f;
    public float cooldown = 1f;

    float nextshot = 0;

    private void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsOwner)
            return;

        Vector2 anglevec = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        angle = Mathf.Atan2(anglevec.y, anglevec.x)*Mathf.Rad2Deg - 90f;

        firePointRotator.rotation = Quaternion.Euler(0, 0, angle);
        

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
        if(!IsOwner)
            return;

        GameObject bullet = Instantiate(bullet_prefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}