using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour
{
    public float FireballSpeed;
    public Transform PlayerPosition;
    public Vector2 target;
    public float FireballDamage = 10f;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(PlayerPosition.position.x, PlayerPosition.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        LastLocation();
    }
    void LastLocation()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, FireballSpeed * Time.deltaTime);
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyFireball();
        }
    }
    void DestroyFireball()
    {
        Destroy(gameObject);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyFireball();
            other.transform.SendMessage("DamagePlayer", FireballDamage);
        }
    }
}