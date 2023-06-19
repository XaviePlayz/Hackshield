using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System;

public class SceneManagerScript : MonoBehaviour
{
    private bool isAdditiveSceneLoaded = false;
    public static int currentCount = 0;
    public CharacterControlScript player;
    public GameObject startingChat;

    private void Start()
    {
        player.enabled = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleAdditiveScene();
        }
    }

    public void ToggleAdditiveScene()
    {

        if (isAdditiveSceneLoaded)
        {
            player.inComputer = false;
            // Unload the additive scene
            SceneManager.UnloadSceneAsync("Question");
            isAdditiveSceneLoaded = false;
            if (stateHolder.maxCharacters > stateHolder.currentEncounter + 1)
            {
                stateHolder.currentEncounter ++;
            }
            else 
                stateHolder.currentEncounter = 0;
            }
        else
        {
            player.inComputer = true;
            // Load the additive scene additively
            SceneManager.LoadSceneAsync("Question", LoadSceneMode.Additive);
            isAdditiveSceneLoaded = true;
        }       
    }

    public void StartGame()
    {
        player.enabled = true;
        startingChat.SetActive(false);
    }
}
