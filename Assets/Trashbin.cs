using UnityEngine;

public class Trashbin : MonoBehaviour
{
    [SerializeField] public int TrashCount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trash"))
        {
            TrashCount += 1;
            Destroy(collision.gameObject);
        }
    }
}
