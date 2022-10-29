using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controls : MonoBehaviour
{
    
    private bool isGrounded = false;
    private float speed = 10.0f;

    private Transform playerGroundCheck;
    [SerializeField] private LayerMask Ground;
    private float JumpForce = 500.0f;
    
    private Rigidbody2D rg2d;
    private BoxCollider2D box2d;
    private SpriteRenderer spritex;

    Animator anim;

    void Start()
    {
        rg2d = GetComponent<Rigidbody2D>();
        box2d = transform.GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        spritex = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        // IDLE
        if (isGrounded && Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            anim.Play("Idle");
        }
        if (isGrounded && Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") < 0)
        {
            anim.Play("Duck");
        }

        // WWALKING
        float hrz = Input.GetAxis("Horizontal");
        if (isGrounded && Input.GetAxis("Horizontal") > 0.5f)
        {
            anim.Play("Skip");
            //spritex.flipX = false;
        }
        else if (isGrounded && Input.GetAxis("Horizontal") < -0.5f)
        {
            anim.Play("Skip");
            //spritex.flipX = true;
        }

        // SPRITE FLIPPING
        if (Input.GetAxis("Horizontal") > 0.5f)
        {
            spritex.flipX = false;
        }
        else if (Input.GetAxis("Horizontal") < -0.5f)
        {
            spritex.flipX = true;
        }

        // JUMPING
        isGrounded = GroundCheck();
        if (isGrounded && Input.GetAxis("Jump") > 0)
        {
            rg2d.AddForce(new Vector2(0.0f, JumpForce));
            isGrounded = false;
            anim.Play("Jump");
        }

        rg2d.velocity = new Vector2(hrz * speed, rg2d.velocity.y);

    }

    private bool GroundCheck()
    {
        float extraHeight = .1f;
        RaycastHit2D raycastHit = Physics2D.Raycast(box2d.bounds.center, Vector2.down, box2d.bounds.extents.y + extraHeight, Ground);
        Color rayColor;
        if(raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
            anim.Play("Jump");
        }
        Debug.DrawRay(box2d.bounds.center, Vector2.down * (box2d.bounds.extents.y + extraHeight), rayColor);
        return raycastHit.collider != null;
    }
}
