using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogueScript;
    private bool playerDetected;

    // Detect Trigger Player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If we Trigger the player enable playerdetected and show indicator
        if (collision.tag == "Player")
        {
            playerDetected = true;
            dialogueScript.ToogleIndicator(playerDetected);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        // If we Lost Trigger the player disable playerdetected and hide indicator
        if (collision.tag == "Player")
        {
            playerDetected = false;
            dialogueScript.ToogleIndicator(playerDetected);
            dialogueScript.EndDialogue();
        }
    }

    // While detect if interact
    private void Update()
    {
        if (playerDetected && Input.GetKeyDown(KeyCode.E))
        {
            dialogueScript.StartDialogue();
        }
    }
}

