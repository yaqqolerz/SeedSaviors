using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    // Fields
    //Window
    public GameObject window;
    //Indicator
    public GameObject indicator;
    // Text Component
    public TMP_Text dialogueText;
    //Dialog List 
    public List<string> dialogue;
    // Writing Speed
    public float writingSpeed;
    //Index On Dialog
    private int index;
    //Character Index
    private int charIndex;
    // Started Boolean
    private bool started;
    // Wait for next boolean
    private bool waitForNext;

    private void Awake()
    {
        ToogleIndicator(false);
        ToogleWindow(false);
    }

    private void ToogleWindow(bool show)
    {
        window.SetActive(show);
    }

    public void ToogleIndicator(bool show)
    {
        indicator.SetActive(show);
    }

    // Start Dialog
    public void StartDialogue()
    {
        if (started)
            return;

        // Boolean to Indicate
        started = true;
        // Show the Window
        ToogleWindow(true);
        // Hide Indicator
        ToogleIndicator(false);
        // Start First Dialog
        GetDialogue(0);
    }

    private void GetDialogue(int i)
    {
        // Start Index at Zero (0)
        index = i;
        //Reset The Character Index
        charIndex = 0;
        // Clear The Dialogue Component Text
        dialogueText.text = string.Empty;
        // Start Writing (Nulis)
        StartCoroutine(Writing());
    }

    // End Dialog
    public void EndDialogue()
    {
        // Stop All Ienumerators
        StopAllCoroutines();
        // Hide The Window
        ToogleWindow(false);
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
            //Wait X Seconds
            yield return new WaitForSeconds(writingSpeed);
            // Restart The Same Proses
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
        if (!started)
            return;

        if (waitForNext && Input.GetKeyDown(KeyCode.E))
        {
            waitForNext = false;
            index++;

            //check if are in the scape fo dialogue list
            if (index < dialogue.Count)
            {
                // if so fetch the next dialogue 
                GetDialogue(index);
            }
            else
            {
                // If not end the dialogue process
                ToogleIndicator(true);
                EndDialogue();
            }
        }
    }
}
