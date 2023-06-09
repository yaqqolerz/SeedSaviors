using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{

    public Transform A;
    public Transform B;
    public Vector3 targetPosition;

    public Transform laser;
    public float laserTime;

    public AudioClip bossLaugh;
    public AudioClip bossLaser;

    void Start()
    {
        targetPosition = A.position;

        BossLaugh();
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<Character>().life <= 0)
        {
            return;
        }


        laserTime += Time.deltaTime;
        if(laserTime > 6f)
        {
            laserTime = 0f;

            laser.gameObject.SetActive(false);
            laser.GetChild(0).GetComponent<TrailRenderer>().Clear();
            laser.position = transform.position;
            laser.gameObject.SetActive(true);

            GetComponent<AudioSource>().PlayOneShot(bossLaser, 0.5f);

        }

        if(transform.position == A.position)
        {
            targetPosition = B.position;
        }
        if (transform.position == B.position)
        {
            targetPosition = A.position;
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, 4 * Time.deltaTime);
    }

    private void BossLaugh()
    {
        Invoke("BossLaugh", 15);
        GetComponent<AudioSource>().PlayOneShot(bossLaugh);
    }
}
