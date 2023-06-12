using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public Transform A;
    public Transform B;
    public Transform C;
    public Transform D;

    public Vector3 targetPosition;

    void Start()
    {
        targetPosition = A.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == A.position) 
        {
            targetPosition = B.position;
        }
        if (transform.position == B.position) 
        {
            targetPosition = C.position;
        }
        if (transform.position == C.position)
        {
            targetPosition = D.position;
        }
        if (transform.position == D.position)
        {
            targetPosition = A.position;
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPosition,5 * Time.deltaTime);

        transform.Rotate(0, 0, -500 * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Character>().PlayerDamage(1);
        }
    }
}
