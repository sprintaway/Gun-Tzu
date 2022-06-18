using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator anim;
    public Vector2 movement;

    // Update is called once per frame
    // since framerate changes, we must update in fixed update
    void Update()
    {
        // handles Input from player
        // Old input system
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude); // skip calculating square root
    }

    // FixedUpdate is called once per physics frame
    void FixedUpdate()
    {
        // handles movement, by moving rigid body to a position and collides with objects
        // Time.fixedDeltaTime is the time between physics frames, so movement sticks to framerate
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
