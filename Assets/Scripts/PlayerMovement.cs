using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f, doubleJumpForce = 15f;

    private Rigidbody2D playerRB;
    private bool isGrounded, canDoubleJump;

    private SpriteRenderer render;
    [SerializeField] private SpriteRenderer injuriedRender;
    private Animator anim;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    public void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 moveDirection = new Vector2(horizontalInput, 0f);
        playerRB.velocity = new Vector2(moveDirection.x * moveSpeed, playerRB.velocity.y);

        if(horizontalInput == 0)
        {
            anim.Play("Idle");
        }
        else
        {
            anim.Play("Walk");
            render.flipX = injuriedRender.flipX = horizontalInput < 0 ? true : false;
        }
    }

    public void Jump()
    {
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Vector2 jumpSpeed = new Vector2(0f, jumpForce);
            playerRB.velocity = Vector2.up * jumpSpeed;
        }

        else
        {
            if (canDoubleJump)
            {
                DoubleJump();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            var value = GameManger.Instance.GetDepress() + 20;
            GameManger.Instance.SetDepress(value);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    
    void DoubleJump()
    {
        Vector2 doubleJumpVel = new Vector2(0.0f, doubleJumpForce);
        playerRB.velocity = Vector2.up * doubleJumpVel;
        canDoubleJump = false;
    }
}
