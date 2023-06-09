using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float runSpeed;
    public Animator playerAnimator;
    private Rigidbody2D playerRigidbody;

    [Header("Jump")]
    public float jumpForce;
    public Transform groundcheck;
    private bool isGrounded;
    private bool doDoubleJump;
    public LayerMask groundFloor;
    public GameObject jumpEffect;

    [Header("Attack")]
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 20;
    public float attackRate = 2f;
    public float nextAttackTime = 0f;

    [Header("Range Attack")]
    public PlayerShoot Fire;
    public Transform shootPoint;

    // Start is called before the first frame update
    void Start()
    {
        //Get Component
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //player movement
        playerRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * runSpeed, playerRigidbody.velocity.y);
        //Flipping Player
        if (playerRigidbody.velocity.x > 0)
        {
            transform.localScale = new Vector3(2, 2, 2);
        }
        else if (playerRigidbody.velocity.x < 0)
        {
            transform.localScale = new Vector3(-2, 2, 2);
        }
        //Check Point
        isGrounded = Physics2D.OverlapCircle(groundcheck.position, 0.1f, groundFloor);
        //Jumping
        if (Input.GetButtonDown("Jump") && (isGrounded || doDoubleJump))
        {
            Instantiate(jumpEffect, transform.position, transform.rotation);
            if (isGrounded)
            {
                doDoubleJump = true;
            }
            else
            {
                doDoubleJump = false;
                playerAnimator.SetTrigger("Double Jump");
            }
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpForce);
        }
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                MeleAttack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }


        playerAnimator.SetBool("IsGrounded", isGrounded);
        playerAnimator.SetFloat("Speed", Mathf.Abs(playerRigidbody.velocity.x));

        //Fire nembak
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(Fire, shootPoint.position, shootPoint.rotation).moveDirection = new Vector2(transform.localScale.x, 0);
        }

    }

    public void MeleAttack()
    {
        // play Attack
        playerAnimator.SetTrigger("Attack");
        //Detect Enemy area attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        //Damage
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
