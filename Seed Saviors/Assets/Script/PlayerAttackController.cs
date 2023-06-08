using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    public bool AttackInputRecieved;
    public bool AllowedToAttack;
    public bool PlayerIsAttacking;
    public Animator anim;
    // public bool CanDoCombo;
    // public float InputTimer = 0.5f; //Combo sistem
    // public float lastInputTime;
    public float AttackRadius;
    public Transform AttackPosition;
    public LayerMask WhatIsEnemy;
    public float TotalAttackDamage;
    public float NormalDamage;
    public float CurrentPlayerHeath = 100f;
    public ParticleSystem burstParticles;
    public HealthManager health;

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
        // CheckCombo(); //Combo Sistem
    }
    void CheckIfEnemyDetected()
    {
        Collider2D[] EnemyHit = Physics2D.OverlapCircleAll(AttackPosition.position, AttackRadius, WhatIsEnemy);
        foreach (Collider2D collider in EnemyHit)
        {
            collider.transform.SendMessage("DamageEnemy", TotalAttackDamage);
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(AttackPosition.position, AttackRadius);
    }
    // void CheckCombo()
    // {
    //     if (Time.time - lastInputTime <= InputTimer)
    //     {
    //         CanDoCombo = true;
    //     }
    //     else  Combo Sistem
    //     {
    //         CanDoCombo = false;
    //     }
    // }
    void CheckifAttackKeyPressed()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (AllowedToAttack == true)
            {
                AttackInputRecieved = true;
                // lastInputTime = Time.time; //Combo sistem
            }
        }
    }

    void DoAttacks()
    {
        if (AttackInputRecieved == true)
        {
            if (PlayerIsAttacking == false)
            {
                anim.SetBool("Attack1", true); // No Combo
                TotalAttackDamage = NormalDamage;
                // if (CanDoCombo == false)
                // {
                //     anim.SetBool("Attack1", true);
                //TotalAttackDamage=NormalDamage;
                // }                                    //Combo Sistem
                // else if (CanDoCombo == true)
                // {
                //     anim.SetBool("Attack2", true);
                //TotalAttackDamage=NormalDamage * 1.5f;
                // }
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
    // void SecondAttackDone()
    // {
    //     PlayerIsAttacking = false;
    //     anim.SetBool("Attack2", false); sistem combo
    //     CanDoCombo = false;
    //      TotalAttackDamage=NormalDamage;
    // }

    public virtual void DamagePlayer(float amount)
    {
        CurrentPlayerHeath -= amount;
        anim.SetTrigger("Hit");
        health.SetHealth(CurrentPlayerHeath);
        if (CurrentPlayerHeath <= 0.0f)
        {
            Destroy(gameObject);
            Instantiate(burstParticles, transform.position, transform.rotation);
        }
    }
}
