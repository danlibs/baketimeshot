using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    public bool IsGrounded;

    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField]
    private bool facingRight;
    [SerializeField]
    private bool jumping = false;
    private float xMov;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
    }

    private void Update()
    {
        xMov = Input.GetAxisRaw("Horizontal");

        if (IsGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space) && !jumping)
            {
                rb.AddForce(Vector2.up * JumpForce * Time.fixedDeltaTime, ForceMode2D.Impulse);
            }
            else if (xMov == 0)
            {
                anim.Play("Idle");
            }
            else if (xMov != 0)
            {
                anim.Play("Walking");
            }
        }
        else
        {
            anim.Play("Jumping");
        }       

        if (xMov < 0 && facingRight)
        {
            Flip();
        }
        else if (xMov > 0 && !facingRight)
        {
            Flip();
        }
    }

    private void FixedUpdate() {
        rb.velocity = new Vector2(xMov * Speed * Time.fixedDeltaTime, rb.velocity.y);


    }

    private void Flip()
    {
        facingRight = !facingRight;
        this.transform.Rotate(0, 180, 0);
    }
}
