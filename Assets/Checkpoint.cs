using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private bool activated = false;
    private Vector3 respawnPosition;
    [SerializeField] private PlayerAttackController plr;
    [SerializeField] private int currlevel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !activated)
        {
            plr.currentlevel = currlevel;
        }
    }

    /*private void ActivateCheckpoint(Vector3 playerPosition)
    {
        activated = true;
        respawnPosition = playerPosition;
        //Debug.Log("Checkpoint activated!");
        CheckpointManager.Instance.ActivateCheckpoint(respawnPosition);
    }

    public Vector3 GetRespawnPosition()
    {
        return respawnPosition;
    }*/
}
