using UnityEngine;
using UnityEngine.SceneManagement;

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
        }
        else
        {
            // Load the additive scene additively
            SceneManager.LoadSceneAsync("Question", LoadSceneMode.Additive);
        }

        isAdditiveSceneLoaded = !isAdditiveSceneLoaded;
    }

}
