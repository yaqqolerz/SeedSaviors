using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // References
    [SerializeField] private Rigidbody2D player;
    [SerializeField] public float speed;
    [SerializeField] private Animator anim;
    // Grounded Checker & Jump Variables
    public bool isGrounded;
    public bool canJump;
    [SerializeField] private float jumpHeight = 2.5f;

    private Vector2 movementInput; //Variable to store the movement input

    private void Update()
    {
        // Move
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        movementInput = new Vector2(horizontalInput, player.velocity.y);
        player.velocity = new Vector2(horizontalInput * speed, player.velocity.y);

        // Flip player to direction
        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.W) && isGrounded && canJump)
        {
            Jump();
        }

        // Set animator parameters
        anim.SetBool("Walk", Mathf.Abs(horizontalInput) > 0);
    }


    private void Jump()
    {
        player.velocity = new Vector2(player.velocity.x, jumpHeight);
    }

    // get the movement input
    public Vector2 GetMovementInput()
    {
        return movementInput;
    }
}