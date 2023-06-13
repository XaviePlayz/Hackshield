using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System;

public class SceneManagerScript : MonoBehaviour
{
    private bool isAdditiveSceneLoaded = false;

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
           
            // Unload the additive scene
            SceneManager.UnloadSceneAsync("Question");
            isAdditiveSceneLoaded = false;
        }
        else
        {
            // Load the additive scene additively
            SceneManager.LoadSceneAsync("Question", LoadSceneMode.Additive);
            isAdditiveSceneLoaded = true;
        }

        
    }

}
