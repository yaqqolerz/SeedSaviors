using UnityEngine;
using UnityEngine.SceneManagement;

public class level4restart : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene("Level4");
        }
    }
}
