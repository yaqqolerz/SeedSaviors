using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movingSpeed = 5f;
    public float moveDirection = 0f;
    public Rigidbody2D playerBody;
    public bool PlayerFacingRight = true;
    public float jumpSpeed = 10f;
    public bool CanPlayerJump;
    public Transform FootPosition;
    public GameObject JumpEffect;
    AudioSource Jumpsound;

    public float groundRadius;
    public LayerMask WhatIsGround;
    public bool IsGrounded;
    public bool Running;
    public Animator anim;
    public Transform pauseScreen;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        CanPlayerJump = true;
        Jumpsound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        CheckInputDirection();
        CheckIfPlayerIsGrounded();
        /*CheckIfCanJump();*/
        CheckIfWalking();
        AnimationUpdater();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseScreen.GetComponent<Pause>().enabled = !pauseScreen.GetComponent<Pause>().enabled;
        }
    }
    void AnimationUpdater()
    {
        anim.SetBool("TriggerRun", Running);
        //anim.SetFloat("Jumpingvelocity", playerBody.velocity.y);
        anim.SetBool("OnGround", IsGrounded);
    }
    void CheckIfWalking()
    {
        if (IsGrounded == true && playerBody.velocity.x != 0)
        {
            Running = true;
        }
        else
        {
            Running = false;
        }
    }
    void CheckIfCanJump()
    {
        if (IsGrounded == true && playerBody.velocity.y <= 0.1)
        {
            CanPlayerJump = true;
        }
        else
        {
            CanPlayerJump = false;
        }
    }
    void CheckIfPlayerIsGrounded()
    {
        IsGrounded = Physics2D.OverlapCircle(FootPosition.position, groundRadius, WhatIsGround);
    }
    void OnDrawGizmo()
    {
        Gizmos.DrawWireSphere(FootPosition.position, groundRadius);
    }
    void CheckInput()
    {
        moveDirection = Input.GetAxisRaw("Horizontal");
        playerBody.velocity = new Vector2(movingSpeed * moveDirection, playerBody.velocity.y);
        if (Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }
    }

    void Jump()
    {
        Jumpsound.Play();
        Instantiate(JumpEffect, transform.position, transform.rotation);
        if (CanPlayerJump == true && IsGrounded == true)
        {
            playerBody.velocity = new Vector2(playerBody.velocity.x, jumpSpeed);
        }
    }
    void CheckInputDirection()
    {
        if (PlayerFacingRight == true && moveDirection < 0)
        {
            Flip();
        }
        else if (PlayerFacingRight == false && moveDirection > 0)
        {
            Flip();
        }
    }
    void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
        PlayerFacingRight = !PlayerFacingRight;
    }

    public Vector2 GetMovementInput()
    {
        return playerBody.velocity;
    }
}
