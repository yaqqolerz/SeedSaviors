using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    /*public Animator enemyanim;*/
    public int maxHealth = 100;
    int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //play hurt anim
        /*enemyanim.SetTrigger("Hurt");*/
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("Enemy died");
        //die anim
        /*enemyanim.SetBool("IsDead", true);*/
        //desable enemy
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        Destroy(gameObject, 1);
    }
}
