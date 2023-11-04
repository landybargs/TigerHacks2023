using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Numerics; // You don't need System.Numerics for this script

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int speed = 5;
    [SerializeField] private float deceleration = 10f; // Deceleration Field
    private UnityEngine.Vector2 movement;
    private Rigidbody2D rb;
    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnMovement(InputValue value)
    {
        movement = value.Get<UnityEngine.Vector2>();

        if (movement.x != 0 || movement.y != 0)
        {
            animator.SetFloat("X", movement.x);
            animator.SetFloat("Y", movement.y);

            animator.SetBool("IsWalking", true);
        } else {
            animator.SetBool("IsWalking", false);
        }
    }

    private void FixedUpdate()
    {
        UnityEngine.Vector2 desiredVelocity = movement * speed;

        UnityEngine.Vector2 velocityChange = desiredVelocity - rb.velocity;

        rb.AddForce(velocityChange * speed);

        if (movement == UnityEngine.Vector2.zero)
        {
            UnityEngine.Vector2 decelerationForce = -rb.velocity.normalized * deceleration;

            if (decelerationForce.magnitude > rb.velocity.magnitude)
            {
                rb.velocity = UnityEngine.Vector2.zero;
            }
            else
            {
                rb.AddForce(decelerationForce);
            }
        }

        // Variant 1, 2, and 3 are commented out for clarity.
        // rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        // if (movement.x != 0 || movement.y != 0)
        // {
        //     rb.velocity = movement * speed;
        // }
        // rb.AddForce(movement * speed);
    }
}
