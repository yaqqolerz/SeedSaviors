using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] private PlayerMovement plr;
    [SerializeField] private Rigidbody2D rb;
    private bool isPlayerInsideTrigger = false;
    private bool isSpaceKeyPressed = false;
    public bool isTouchingGround;
    [SerializeField] private float maxAngularVelocity;

    [SerializeField] private AudioSource pushSound;
    [SerializeField] private bool soundPlaying = false;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
                isPlayerInsideTrigger = true;
                plr.CanPlayerJump = false;
                plr.movingSpeed = plr.movingSpeed / 2.5f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInsideTrigger = false;
            plr.CanPlayerJump = true;
            plr.movingSpeed = plr.movingSpeed * 2.5f;
        }
    }

    private void Update()
    {
        if (isPlayerInsideTrigger)
        {
            // Check if space key is pressed
            isSpaceKeyPressed = Input.GetKey(KeyCode.E);
        }
        if (Input.GetKeyUp(KeyCode.E)){
            pushSound.Stop();
        }
    }   


    private void FixedUpdate()
    {
        if (isPlayerInsideTrigger && isSpaceKeyPressed && isTouchingGround)
        {
            if(pushSound != null)
            {
                if (!soundPlaying)
                {
                    if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
                    {
                        pushSound.Play();
                        soundPlaying = true;
                    }
                }

                if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.E))
                {
                    pushSound.Stop();
                    soundPlaying = false;
                }
            }
            
            Vector2 direction = plr.GetMovementInput(); // Get the movement input from the player script

            // Normalize the direction vector only if the player is giving input
            if (direction.magnitude > 0)
            {
                
                direction.Normalize();
                rb.MovePosition(rb.position + direction * (plr.movingSpeed + 0.1f) * Time.fixedDeltaTime);

            }

            if (rb.angularVelocity > maxAngularVelocity)
            {
                rb.angularVelocity = maxAngularVelocity;
            }
        }
    }
}
