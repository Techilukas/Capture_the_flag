using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour
{
    public float damage  =  25;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject go = collision.gameObject;

        if (go.tag == "player")
        {
            player player = go.GetComponent<player>();
            player.take_damage(damage);
        }

        Destroy(gameObject);
    }
}
