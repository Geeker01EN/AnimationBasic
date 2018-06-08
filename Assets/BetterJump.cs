using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour {

    Rigidbody2D rb;
    Animator animator;

    [SerializeField] BoxCollider2D[] boxCollider;

    bool jumped;
    bool grounded;

    [SerializeField] float jumpSpeed;

    [SerializeField] float fallMult;
    [SerializeField] float ultraJumpMult;
    [SerializeField] float risingMult;

    void Awake () {
        rb = GetComponent<Rigidbody2D>();
        jumped = false;
        grounded = true;
        animator = GetComponent<Animator>();
	}
	
	void Update () {
        if (Input.GetButtonDown("Jump"))
        {
            jumped = true;
            animator.SetBool("isJumping", true);
        }
	}

    void FixedUpdate()
    {
        if (jumped && grounded)
        {
            grounded = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
        else jumped = false;

        if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallMult;
        }
        else if (rb.velocity.y > 0 && Input.GetButton("Jump"))
        {
            rb.gravityScale = ultraJumpMult;
        }
        else if (rb.velocity.y > 0)
        {
            rb.gravityScale = risingMult;
        }
        else
        {
            rb.gravityScale = 1;
        }
    }

    void OnCollisionEnter2D(Collision2D info)
    {
        if (info.otherCollider == boxCollider[1])
        {
            grounded = true;
            animator.SetBool("isJumping", false);
        }
    }
}
