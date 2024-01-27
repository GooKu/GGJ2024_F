using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f, doubleJumpForce = 8f;

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
        float moveDir = Input.GetAxis("Horizontal");

        if( Mathf.Abs(moveDir) > 0.2f)
        {
            Vector2 playerVel = new Vector2(moveDir * moveSpeed, playerRB.velocity.y);
            playerRB.velocity = playerVel;
        }

        else
        {
            playerRB.velocity = new Vector2(0, playerRB.velocity.y);
        }
        
        if(moveDir == 0)
        {
            anim.Play("Idle");
        }
        else
        {
            anim.Play("Walk");
            render.flipX = injuriedRender.flipX = moveDir < 0 ? true : false;
        }
    }

    public void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                Vector2 jumpVel = new Vector2(0f, jumpForce);
                playerRB.velocity = Vector2.up * jumpVel;
                canDoubleJump = true;
            }

            else if (canDoubleJump && canDoubleJump)
            {
                DoubleJump();
                canDoubleJump = false;
            }
        }

        
    }

    void DoubleJump()
    {
        Vector2 doubleJumpVel = new Vector2(0.0f, doubleJumpForce);
        playerRB.velocity = Vector2.up * doubleJumpVel;
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
}
