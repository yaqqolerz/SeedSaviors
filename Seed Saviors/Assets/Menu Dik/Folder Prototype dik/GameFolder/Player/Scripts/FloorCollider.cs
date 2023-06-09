 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCollider : MonoBehaviour
{
    public AudioSource audioSource;
    public bool canJump;
    public AudioClip groundedSound;

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
        if (collision.CompareTag("Floor"))
        {
            canJump = true;
            audioSource.PlayOneShot(groundedSound, 0.3f);
        } 
    }



}
