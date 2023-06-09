using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap2Sound : MonoBehaviour
{

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
    public void PlaySound()
    {
        audioSource.PlayOneShot(clip, 0.2f);
    }
}
