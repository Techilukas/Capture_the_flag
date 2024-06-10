using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public GameObject shooter;

    public float damage = 20f;

     // Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D collision)
    {


        //explosion


        Destroy(gameObject);

    }

    
}