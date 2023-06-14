using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControler : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 vel;
    public AudioSource audioSource;
    public AudioClip attack1Sound;
    public AudioClip attack2Sound;
    public AudioClip damageSound;
    public AudioClip dashSound;
    [SerializeField] private int jumpforce;

    public Transform floorCollider;
    public Transform sprite;

    public Transform gameOverScreen;
    public Transform pauseScreen;

    public int comboNum;
    public float comboTime;
    public float dashTime;

    public string currentLevel;

    public Transform FootPosition;

    public float groundRadius;
    public LayerMask WhatIsGround;
    public bool IsGrounded;
    public bool CanPlayerJump = true;
    [SerializeField]public float movingSpeed;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        currentLevel = SceneManager.GetActiveScene().name;
        DontDestroyOnLoad(transform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfPlayerIsGrounded();
        if (!currentLevel.Equals(SceneManager.GetActiveScene().name))
        {
            currentLevel = SceneManager.GetActiveScene().name;
            transform.position = GameObject.Find("Spawn").transform.position;
        } 


         
        if(GetComponent<Character>().life <= 0)
        {
            gameOverScreen.GetComponent<GameOver>().enabled = true;
            rb.simulated = false;
            this.enabled = false;
        }

        if (Input.GetButtonDown("Cancel"))
        {
            pauseScreen.GetComponent<Pause>().enabled = !pauseScreen.GetComponent<Pause>().enabled;
        }

        dashTime= dashTime + Time.deltaTime;
        if (Input.GetButtonDown("Fire2") && dashTime > 1)
        {
            audioSource.PlayOneShot(dashSound, 0.5f);

            dashTime = 0;
            sprite.GetComponent<Animator>().Play("Playerdash",-1);
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0;
            rb.AddForce(new Vector2(sprite.localScale.x * 800, 0));
            Invoke("RestoreGravityScale", 0.4f);
        }


        comboTime = comboTime + Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && comboTime > 0.3f)
        {
            comboNum++;
            if (comboNum > 2)
            {
                comboNum = 1;
            }

            comboTime = 0;
            sprite.GetComponent<Animator>().Play("PlayerAttack" + comboNum, -1);

            if (comboNum == 1)
            {
                audioSource.PlayOneShot(attack1Sound, 0.2f);

            }
            else
            {
                audioSource.PlayOneShot(attack2Sound, 0.2f);
            }

        }

        if (comboTime >= 1)
        {
            comboNum = 0;
        }


        if (Input.GetButtonDown("Jump") && IsGrounded && CanPlayerJump /*&& floorCollider.GetComponent<FloorCollider>().canJump == true*/)
        {
            sprite.GetComponent<Animator>().Play("Playerjump", -1);
            rb.velocity = Vector2.zero;
            /*floorCollider.GetComponent<FloorCollider>().canJump = false;*/
            rb.AddForce(new Vector2(0, jumpforce));

        }

        vel = new Vector2(Input.GetAxisRaw("Horizontal") * movingSpeed, rb.velocity.y);



        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            sprite.localScale = new Vector3(Input.GetAxisRaw("Horizontal"), 1, 1);
            sprite.GetComponent<Animator>().SetBool("PlayerRu", true);
        }
        else
        {
            sprite.GetComponent<Animator>().SetBool("PlayerRu", false);
        }

    }

    private void FixedUpdate()
    {
        if(dashTime > 0.4f)
        {
            rb.velocity = vel;
        }
       
    }

    public void DestroyPlayer()
    {
        Destroy(transform.gameObject);
    }

    void RestoreGravityScale()
    {
        rb.gravityScale = 6;
    }

    void CheckIfPlayerIsGrounded()
    {
        IsGrounded = Physics2D.OverlapCircle(FootPosition.position, groundRadius, WhatIsGround);
    }

    public Vector2 GetMovementInput()
    {
        return rb.velocity;
    }
}


