using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float max_health = 100;
    public float health;

    CinemachineVirtualCamera virtualCamera;
    public GameObject virtualcam_prefab;

    public void Start()
    {
        virtualCamera = Instantiate(virtualcam_prefab).GetComponent<CinemachineVirtualCamera>();
        virtualCamera.Follow = transform;

        health = max_health;
    }

    public void take_damage(float amount)
    {
        health -= amount;

        if (health <= 0) die();
    }

    void die()
    {
        Destroy(gameObject);
    }

}
