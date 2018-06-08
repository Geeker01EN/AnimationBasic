using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

    Animator animator;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;

    [SerializeField] float speed;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            spriteRenderer.flipX = true;
            animator.SetBool("isRunning", true);
            animator.SetBool("isIdle", false);
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            spriteRenderer.flipX = false;
            animator.SetBool("isRunning", true);
            animator.SetBool("isIdle", false);
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else
        {
            animator.SetBool("isIdle", true);
            animator.SetBool("isRunning", false);
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
	}
}
