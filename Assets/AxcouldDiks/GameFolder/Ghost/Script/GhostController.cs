using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    public Transform a;
    public Transform b;

    public Transform sprite;

    public bool goRight;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (goRight == true)
        {
            sprite.localScale = new Vector3(-1, 1, 1);

            if (Vector2.Distance(transform.position, b.position) < 0.1f)
            {
                transform.position = a.position;
            }
            transform.position = Vector2.MoveTowards(transform.position, b.position, 20f * Time.deltaTime);
        }
        else
        {
            sprite.localScale = new Vector3(1, 1, 1);
            if (Vector2.Distance(transform.position, a.position) < 0.1f)
            {
                transform.position = b.position;
            }

            transform.position = Vector2.MoveTowards(transform.position, a.position, 20f * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SendMessage("DamagePlayer", 10);
        }
    }
}
