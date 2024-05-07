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
        if (Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Vertical") != 0)
        {
            movement.x *= 0.7f;
            movement.y *= 0.7f;
        }

        rb.MovePosition(movement * runSpeed * Time.deltaTime + rb.position);
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90;
        rb.rotation = angle;
    }

   
}