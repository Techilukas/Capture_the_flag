using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.Video;

public class movescript_wasd : NetworkBehaviour
{
    Rigidbody2D body;
    public GameObject test;
    float horizontal;
    float vertical;

    public float runSpeed = 20.0f;
    public float direction = 0;
    public float rotation;
    public bool inputchanged;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        inputchanged = true;
    }

    void Update()
    {
        if(!IsOwner)
            return;
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
        if (!IsOwner)
            return;
        if (horizontal != 0 || vertical != 0 && inputchanged)
        {
            direction = math.atan2(-vertical, horizontal) * 180 / math.PI + 90;
            inputchanged = false;
        }
        rotation = body.rotation + 90;
        var dir = Quaternion.Euler(20, 200, direction);
        body.transform.rotation = dir;
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }
}
