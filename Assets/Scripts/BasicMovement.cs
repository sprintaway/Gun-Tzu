using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    public Animator animator;

    public float runSpeed = 10f;

    public float walkSpeed = 5f;

    public bool run = false;
    
    Vector2 movement;
    

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = runSpeed;
            animator.SetBool("Run", true);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift)) 
        {
            moveSpeed = walkSpeed;
            animator.SetBool("Run", false);
        }   
        
    }

    void FixedUpdate() 
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}
