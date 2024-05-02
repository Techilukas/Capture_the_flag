using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float max_health = 100;
    public float health;

    public void Start()
    {
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
