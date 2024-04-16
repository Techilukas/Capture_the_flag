using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movescript_wasd : MonoBehaviour
{
    Rigidbody2D body;
    GameObject test;
    float horizontal;
    float vertical;

    public float runSpeed = 20.0f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if(Input.GetAxisRaw("Fire3") == 1)
        {
            horizontal *= 1.5f;
            vertical *= 1.5f;
        }
        if (horizontal !=0 && vertical != 0)
        {
            horizontal *= 0.7f;
            vertical *= 0.7f;
        }
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
}
