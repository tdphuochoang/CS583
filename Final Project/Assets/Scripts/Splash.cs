using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour
{
    public static string scene;

    void Start()
    {
        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        if (sceneName == "SplashScene")
        {
            StartCoroutine(Splas());
        }
    }

    IEnumerator Splas()
    {
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene("Main");
    }
}
