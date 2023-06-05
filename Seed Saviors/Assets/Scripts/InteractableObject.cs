using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] private PlayerMovement plr;
    [SerializeField] private Rigidbody2D rb;
    private bool isPlayerInsideTrigger = false;
    private bool isSpaceKeyPressed = false; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInsideTrigger = true;
            plr.canJump = false;
            plr.speed = plr.speed / 2;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInsideTrigger = false;
            plr.canJump = true;
            plr.speed = plr.speed * 2;
        }
    }

    private void Update()
    {
        if (isPlayerInsideTrigger)
        {
            // Check if space key is pressed
            isSpaceKeyPressed = Input.GetKey(KeyCode.Space);
        }
    }

    private void FixedUpdate()
    {
        if (isPlayerInsideTrigger && isSpaceKeyPressed)
        {
            Vector2 direction = plr.GetMovementInput(); // Get the movement input from the player script

            // Normalize the direction vector only if the player is giving input
            if (direction.magnitude > 0)
            {
                
                direction.Normalize();
                rb.MovePosition(rb.position + direction * plr.speed * Time.fixedDeltaTime);

            }
        }
    }
}
