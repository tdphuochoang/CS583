using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StopBackgroundMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        if (sceneName != "Main" || sceneName != "Credit" || sceneName != "Instruction")
        {
            BackGroundMusic.Instance.gameObject.GetComponent<AudioSource>().Pause();
        }

    }

}