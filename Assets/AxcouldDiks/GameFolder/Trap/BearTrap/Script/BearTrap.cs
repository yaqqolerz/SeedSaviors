using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrap : MonoBehaviour
{
    public Transform sprite;
    Transform player;

    public AudioSource audioSource;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            audioSource.PlayOneShot(clip);

            sprite.GetComponent<Animator>().speed = 1;

            sprite.GetComponent<Animator>().Play("Stuck", -1);
            
            collision.transform.position = transform.position;
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            collision.GetComponent<PlayerControler>().sprite.GetComponent<Animator>().SetBool("PlayerRun", false);
            collision.GetComponent<PlayerControler>().sprite.GetComponent<Animator>().Play("PlayerIdle", -1);
            
            GetComponent<BoxCollider2D>().enabled = false;
            
            player = collision.transform;
            
            collision.GetComponent<PlayerControler>().enabled = false;
            
            Invoke("ReleasePlayer", 2);
            Invoke("ResetTrap", 10);
            
        }
    }

    void ReleasePlayer()
    {
        player.GetComponent<PlayerControler>().enabled = true;
    }

     void ResetTrap()
    {
        GetComponent<BoxCollider2D>().enabled = true;
        sprite.GetComponent<Animator>().Play("UnStuck", -1);
    }

}


