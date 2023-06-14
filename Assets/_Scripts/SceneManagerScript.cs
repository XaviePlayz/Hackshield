using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System;

public class SceneManagerScript : MonoBehaviour
{
    private bool isAdditiveSceneLoaded = false;

    public CharacterControlScript player;

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
        }
        else
        {
            player.inComputer = true;
            // Load the additive scene additively
            SceneManager.LoadSceneAsync("Question", LoadSceneMode.Additive);
            isAdditiveSceneLoaded = true;
        }       
    }
}
