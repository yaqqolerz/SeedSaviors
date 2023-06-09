using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Transform player;
    

    
    private void OnEnable()
    {
        player = GameObject.Find("Player").transform;
        transform.right = transform.position - player.position;      
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * -5 * Time.deltaTime;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Character>().PlayerDamage(1);
        }
    }
}
