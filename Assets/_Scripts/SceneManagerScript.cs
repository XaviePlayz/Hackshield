using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System;

public class SceneManagerScript : MonoBehaviour
{
    private bool isAdditiveSceneLoaded = false;
    public CharacterData charD;
    public CharacterDisplay charShow;
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

        }
        else
        {
            // Load the additive scene additively
            SceneManager.LoadSceneAsync("Question", LoadSceneMode.Additive);
            charD.LoadEncountersInOrder();
        }

        isAdditiveSceneLoaded = !isAdditiveSceneLoaded;
    }

}
