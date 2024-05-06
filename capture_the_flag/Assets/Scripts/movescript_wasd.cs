using Unity.Mathematics;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.Video;
using Unity.VisualScripting;

public class movescript_wasd : NetworkBehaviour
{
    public Rigidbody2D rb;
    public Rigidbody2D rbcam;
    Camera cam;

    Vector2 movement;
    Vector2 mousePos;

    public float runSpeed = 20.0f;
 
    private void Start()
    {
        cam = Camera.main;
        rbcam = cam.GetComponent<Rigidbody2D>();
    }



    void Update()
    {
        if (!IsOwner)
            return;

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");


        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        if (!IsOwner)
            return;

        rb.velocity  = movement * runSpeed;

        Vector2 lookDir = mousePos - rb.position;

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90;

        rb.rotation = angle;

        //rbcam.position = rb.position;

    }
}