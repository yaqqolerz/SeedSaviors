using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAttackController : MonoBehaviour
{
    public bool AttackInputRecieved;
    public bool AllowedToAttack;
    public bool PlayerIsAttacking;
    public Animator anim;
    public float AttackRadius;
    public Transform AttackPosition;
    public LayerMask WhatIsEnemy;
    public float TotalAttackDamage;
    public float NormalDamage;
    public float CurrentPlayerHeath = 100f;
    public ParticleSystem burstParticles;
    public HealthManager health;
    //public CheckpointManager checkpointManager;
    [SerializeField] private Transform respawnPos1;
    [SerializeField] private Transform respawnPos2;


    //Checkpoint
    public int currentlevel = 0;

    void Start()
    {
        anim = GetComponent<Animator>();
        health.SetMaxHealth(CurrentPlayerHeath);
    }

    // Update is called once per frame
    void Update()
    {
        CheckifAttackKeyPressed();
        DoAttacks();
    }

    void CheckIfEnemyDetected()
    {
        Collider2D[] EnemyHit = Physics2D.OverlapCircleAll(AttackPosition.position, AttackRadius, WhatIsEnemy);
        foreach (Collider2D collider in EnemyHit)
        {
            collider.GetComponent<Character>().life--;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(AttackPosition.position, AttackRadius);
    }

    void CheckifAttackKeyPressed()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (AllowedToAttack == true)
            {
                AttackInputRecieved = true;
            }
        }
    }

    void DoAttacks()
    {
        if (AttackInputRecieved == true)
        {
            if (PlayerIsAttacking == false)
            {
                anim.SetBool("Attack1", true);
                TotalAttackDamage = NormalDamage;
                PlayerIsAttacking = true;
                AttackInputRecieved = false;
            }
        }
    }

    void firstAttackDone()
    {
        PlayerIsAttacking = false;
        anim.SetBool("Attack1", false);
    }

    public virtual void DamagePlayer(float amount)
    {
        CurrentPlayerHeath -= amount;
        anim.SetTrigger("Hit");
        health.SetHealth(CurrentPlayerHeath);
        if (CurrentPlayerHeath <= 0.0f)
        {
            // Player is dead, respawn at the last activated checkpoint

            RespawnAtLastCheckpoint();
        }
    }

    void RespawnAtLastCheckpoint()
    {
        if(SceneManager.GetActiveScene().name.Equals("Level4"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
            this.GetComponent<PlayerMovement>().enabled = false;
            StartCoroutine(RespawnWithDelay());
        }
    }

    IEnumerator RespawnWithDelay()
    {
        Instantiate(burstParticles, transform.position, transform.rotation);

        yield return new WaitForSeconds(3f); // Wait for 3 seconds

        
        switch (currentlevel)
        {
            case 1:
                Vector3 respawnPosition = respawnPos1.position;
                transform.position = respawnPosition;
                break;
            case 2:
                Vector3 respawnPosition2 = respawnPos2.position;
                transform.position = respawnPosition2;
                break;
        }
        CurrentPlayerHeath = 100f; // Reset player health
        health.SetMaxHealth(CurrentPlayerHeath);
        this.GetComponent<SpriteRenderer>().enabled = true;
        this.GetComponent<PlayerMovement>().enabled = true;
    }
}
