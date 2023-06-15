using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    // Fields
    // Window
    public GameObject window;
    // Indicator
    public GameObject indicator;
    // Text Component
    public TMP_Text dialogueText;
    // Dialog List
    public List<string> dialogue;
    // Writing Speed
    public float writingSpeed;
    // Index On Dialog
    private int index;
    // Character Index
    private int charIndex;
    // Started Boolean
    private bool started;
    // Wait for next boolean
    private bool waitForNext;
    // Flag to check if dialogue has ended
    private bool dialogueEnded;

    private void Awake()
    {
        ToggleIndicator(false);
        ToggleWindow(false);
    }

    private void ToggleWindow(bool show)
    {
        window.SetActive(show);
    }

    public void ToggleIndicator(bool show)
    {
        indicator.SetActive(show);
    }

    // Start Dialog
    public void StartDialogue()
    {
        if (started && !dialogueEnded)
            return;

        // Reset the dialogue state
        started = true;
        dialogueEnded = false;

        // Show the Window
        ToggleWindow(true);
        // Hide Indicator
        ToggleIndicator(false);
        // Start First Dialog
        GetDialogue(0);
    }

    private void GetDialogue(int i)
    {
        // Start Index at Zero (0)
        index = i;
        // Reset The Character Index
        charIndex = 0;
        // Clear The Dialogue Component Text
        dialogueText.text = string.Empty;
        // Start Writing
        StartCoroutine(Writing());
    }

    // End Dialog
    public void EndDialogue()
    {
        // Stop All Coroutines
        StopAllCoroutines();
        // Hide The Window
        ToggleWindow(false);
        // Set dialogueEnded to true
        dialogueEnded = true;
    }

    // Logic
    IEnumerator Writing()
    {
        yield return new WaitForSeconds(writingSpeed);

        string currentDialogue = dialogue[index];
        // Write The Character (Player)
        dialogueText.text += currentDialogue[charIndex];
        // Increase The Character Index
        charIndex++;

        // Make Sure Have Reached The End Of Sentence
        if (charIndex < currentDialogue.Length)
        {
            // Wait X Seconds
            yield return new WaitForSeconds(writingSpeed);
            // Restart The Same Process
            StartCoroutine(Writing());
        }
        else
        {
            // End Sentence and Wait For Next Line
            waitForNext = true;
        }
    }

    private void Update()
    {
        if (!started || dialogueEnded)
            return;

        if (waitForNext && Input.GetKeyDown(KeyCode.E))
        {
            waitForNext = false;
            index++;

            // Check if we are within the scope of the dialogue list
            if (index < dialogue.Count)
            {
                // If so, fetch the next dialogue
                GetDialogue(index);
            }
            else
            {
                // If not, end the dialogue process
                ToggleIndicator(true);
                EndDialogue();
            }
        }
    }

    // Reset the dialogue state when the player exits the trigger area
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            started = false;
            dialogueEnded = false;
        }
    }
}
