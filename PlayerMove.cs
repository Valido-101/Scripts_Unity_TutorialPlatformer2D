using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float runSpeed = 2;
    public float jumpSpeed = 12;

    Rigidbody2D rigidbody2d;
    SpriteRenderer spriterenderer;
    Animator animator;
    BoxCollider2D colliderbox;
    public bool betterJump = false;
    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplier = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        spriterenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        colliderbox = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rigidbody2d.velocity = new Vector2(runSpeed, rigidbody2d.velocity.y);
            spriterenderer.flipX = false;
            animator.SetBool("Running", true);
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rigidbody2d.velocity = new Vector2(-runSpeed, rigidbody2d.velocity.y);
            spriterenderer.flipX = true;
            animator.SetBool("Running", true);
        }
        else
        {
            rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
            animator.SetBool("Running", false);
        }

        //Encontrar GameObjects por su tag: GameObject.FindWithTag("");

        //CheckGround.isGrounded==true
        if (Input.GetKey("space") && CheckGround.isGrounded == true)
        {
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, jumpSpeed);
        }

        if (CheckGround.isGrounded == true)
        {
            animator.SetBool("isGrounded", true);
        }
        else
        {
            animator.SetBool("isGrounded", false);
            animator.SetBool("Running", false);
        }

        if (betterJump == true)
        {
            if (rigidbody2d.velocity.y < 0)
            {
                rigidbody2d.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
            }

            if (rigidbody2d.velocity.y > 0 && !Input.GetKey("space"))
            {
                rigidbody2d.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
            }
        }

        if (animator.GetBool("Hit") == true)
        {
            rigidbody2d.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            colliderbox.isTrigger = true;
        }
        
    }
}
