using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class player : NetworkBehaviour
{
    public float max_health = 100;
    public float health;
    public GameObject Healthbar;
    const float scale = 0.055f;
    const float minscale = 0.2f;

    CinemachineVirtualCamera virtualCamera;
    public GameObject virtualcam_prefab;

    public void Start()
    {
        if (!IsOwner)
            return;
        virtualCamera = Instantiate(virtualcam_prefab).GetComponent<CinemachineVirtualCamera>();
        virtualCamera.Follow = transform;
        health = max_health;

        Healthbar = GameObject.Find("Healthbar");        
        refreshhealthbar();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collider = collision.gameObject;
        
        if (collider.tag == "bullet")
        {
            bullet bullet = collider.GetComponent<bullet>();
            take_damage(bullet.damage);
        }
    }

    public void take_damage(float amount)
    {
        if (!IsOwner)
            return;
        health -= amount;

        if (health <= 0) die();
        refreshhealthbar();
    }

    public void heal(float amount)
    {
        if (!IsOwner)
            return;
        health += amount;
        health = Mathf.Clamp(health, 0, max_health);
        refreshhealthbar();
    }

    void die()
    {
        if (!IsOwner)
            return;
        //Destroy(gameObject);
    }

    void refreshhealthbar()
    {
        if (!IsOwner)
            return;
        Healthbar.transform.localScale = new Vector3(health*scale + minscale, Healthbar.transform.localScale.y, Healthbar.transform.localScale.z);
        Healthbar.transform.localPosition = new Vector3(Healthbar.transform.localScale.x /2  -1.1f, Healthbar.transform.localPosition.y, Healthbar.transform.localPosition.z);
    }

}
