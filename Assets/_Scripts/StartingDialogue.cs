using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingDialogue : MonoBehaviour
{
    public GameObject[] dialogueImages;
    private int currentImageIndex = 0;
    public GameObject Player;

    private void Start()
    {
        Player.SetActive(false);
        // Hide all dialogue images except the first one
        for (int i = 1; i < dialogueImages.Length; i++)
        {
            dialogueImages[i].SetActive(false);
        }
    }

    private void Update()
    {
        // Check for left mouse button click
        if (Input.GetMouseButtonDown(0))
        {
            // Hide the current dialogue image
            dialogueImages[currentImageIndex].SetActive(false);

            // Check if there are more images/dialogue
            if (currentImageIndex < dialogueImages.Length - 1)
            {
                currentImageIndex++;

                // Show the next dialogue image
                dialogueImages[currentImageIndex].SetActive(true);
            }
            else
            {
                // Dialogue is finished, do something (e.g., start the game)
                Player.SetActive(true);
            }
        }
    }
}
