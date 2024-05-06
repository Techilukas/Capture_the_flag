using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float max_health = 100;
    public float health;
    public GameObject Healthbar;
    const float scale = 0.028f;
    const float minscale = 0.2f;

    public void Start()
    {
        health = max_health;
        Healthbar = GameObject.Find("Healthbar");
        refreshhealthbar();
    }

    public void take_damage(float amount)
    {
        health -= amount;

        if (health <= 0) die();
        refreshhealthbar();
    }

    void die()
    {
        Destroy(gameObject);
    }

    void refreshhealthbar()
    {
        Healthbar.transform.localScale = new Vector3(health*scale + minscale, Healthbar.transform.localScale.y, Healthbar.transform.localScale.z);
        Healthbar.transform.localPosition = new Vector3(Healthbar.transform.localScale.x /2  -1, Healthbar.transform.localPosition.y, Healthbar.transform.localPosition.z);
    }

}
