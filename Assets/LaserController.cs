using System.Collections;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    private PlayerAttackController player;
    [SerializeField] private float timer = 3f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttackController>();
        //StartCoroutine(DestroyAfterDelay());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SendMessage("DamagePlayer", 100);
            
            //Destroy(this);
            
        }
    }
    
    /*IEnumerator DestroyAfterDelay()
    {
        //Debug.Log("Timer Started");
        yield return new WaitForSeconds(timer);
        //Debug.Log("Timer reached 0");
        Destroy(gameObject);
        //Debug.Log("Destroyed");
    }*/
}
