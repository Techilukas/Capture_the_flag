using Unity.Mathematics;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.Video;
using Unity.VisualScripting;

public class movescript_wasd : NetworkBehaviour
{
    public Rigidbody2D rb;
    Camera cam;

    public Vector2 movement;
    Vector2 mousePos;
    float angle;

    public float runSpeed = 20.0f;
 
    private void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (!IsOwner)
            return;

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - rb.position;
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90;
    }

    void FixedUpdate()
    {
        if (!IsOwner)
            return;
        rb.velocity = movement.normalized * runSpeed ;
        rb.rotation = angle;

    }

   
}