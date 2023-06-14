using UnityEngine;

public class Trashbin : MonoBehaviour
{
    [SerializeField] public int TrashCount;
    [SerializeField] private AudioSource audioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trash"))
        {
            audioSource.Play();
            TrashCount += 1;
            Destroy(collision.gameObject);
        }
    }
}
