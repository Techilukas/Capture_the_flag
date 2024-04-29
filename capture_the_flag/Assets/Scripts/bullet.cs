using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public GameObject shooter;

    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {


        //explosion
        //damage

        Destroy(gameObject);

    }
}