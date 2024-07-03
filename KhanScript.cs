using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class KhanScript : MonoBehaviour
{
private float horizontal;
private float speed = 8f;
private float JumpingPower = 16f;
private bool IsFacingRight = (true);

[SerializeField] private Rigidbody2D RB;
[SerializeField] private Transform groundCheck;
[SerializeField] private LayerMask groundLayer;



    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            RB.velocity = new Vector2 (RB.velocity.x, JumpingPower);
        }

        if (Input.GetButtonUp("Jump") && RB.velocity.y > 0f)
        {
            RB.velocity = new Vector2 (RB.velocity.x, RB.velocity.y * 0.5f);
        }
        flip();
    }

    private void FixedUpdate ()
    {
        RB.velocity = new Vector2(horizontal * speed , RB.velocity.y);

    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void flip()
    {
        if (IsFacingRight && horizontal< 0f || IsFacingRight && horizontal > 0f)
        {
            IsFacingRight = !IsFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;

        }

    }
}
