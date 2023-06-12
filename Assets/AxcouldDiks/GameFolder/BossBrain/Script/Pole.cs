using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pole : MonoBehaviour
{
    public Transform spike;

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
        if (collision.name.Equals("Attack Collider"))
        {
            spike.GetComponent<Animator>().Play("Spike", -1);
            GetComponent<Animator>().Play("Pole", -1);
            GetComponent<AudioSource>().PlayOneShot(sound);
        }
    }
}
