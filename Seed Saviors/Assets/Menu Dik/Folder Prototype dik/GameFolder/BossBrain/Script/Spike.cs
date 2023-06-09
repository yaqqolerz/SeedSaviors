using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{

    Transform boss;

    public AudioClip sound;
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
        if (collision.CompareTag("enemy"))
        {
            boss = collision.transform;
            collision.GetComponent<BossController>().enabled = false;
            collision.transform.parent = transform;
            collision.transform.localPosition = Vector3.zero;
        }
    }


    public void ReleaseBoss()
    {
        if(boss != null)
        {
            boss.GetComponent<BossController>().enabled = true;
            boss.parent = null;
        }
        
    }

    public void CollisionSound()
    {
        GetComponent<AudioSource>().PlayOneShot(sound);
    }
}
