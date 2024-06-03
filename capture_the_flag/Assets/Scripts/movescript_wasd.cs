using Unity.Mathematics;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.Video;
using Unity.VisualScripting;

public class movescript_wasd : NetworkBehaviour
{
    public Rigidbody2D rb;
    

    public Vector2 movement;
    

    public float runSpeed = 20.0f;
 
    private void Start()
    {
        
    }

    void Update()
    {
        if (!IsOwner)
            return;

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        
    }

    void FixedUpdate()
    {
        if (!IsOwner)
            return;

        rb.velocity = movement.normalized * runSpeed ;
        

    }

   
}