using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float fireSpeed;
    public Vector2 moveDirection;
    private Rigidbody2D fireRB;
    public GameObject fireEffect;
    public int fireDamage;
    // Start is called before the first frame update
    void Start()
    {
        fireRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        fireRB.velocity = moveDirection * fireSpeed;
    }
    private void OnTriggerEnter2D(Collider2D fireHit)
    {
        //fire damage
        if (fireHit.tag == "Enemy")
        {
            fireHit.GetComponent<Enemy>().TakeDamage(fireDamage);
        }
        // fire effect
        Instantiate(fireEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
