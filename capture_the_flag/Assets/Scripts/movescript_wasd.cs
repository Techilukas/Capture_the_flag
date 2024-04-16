using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class movescript_wasd : MonoBehaviour
{
    Rigidbody2D body;
    public GameObject test;
    float horizontal;
    float vertical;

    public float runSpeed = 20.0f;
    float direction = 0;

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
            horizontal *= 2.5f;
            vertical *= 2.5f;
        }
        if (horizontal !=0 && vertical != 0)
        {
            horizontal *= 0.7f;
            vertical *= 0.7f;
        }
    }

    private void FixedUpdate()
    {
        
        if (horizontal != 0 || vertical != 0)
        {
            direction = math.atan2(-vertical, horizontal) * 180 / math.PI + 90;
        }
        
        test.transform.rotation = Quaternion.Euler(20, 200, direction);
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
}
