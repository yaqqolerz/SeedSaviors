using UnityEngine;
using TMPro;
public class Trashbin : MonoBehaviour
{
    [SerializeField] public int TrashCount;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private TextMeshPro text;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trash"))
        {
            audioSource.Play();
            TrashCount += 1;
            text.text = TrashCount.ToString();
            Destroy(collision.gameObject);
        }
    }
}
