using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    public Transform player;


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
            if (player.GetComponent<PlayerControler>().comboNum == 1)
            {
                collision.GetComponent<Character>().life--;
            }
            
            if (player.GetComponent<PlayerControler>().comboNum == 2)
            {
                collision.GetComponent<Character>().life -= 2;
            }

        }
    }
}
