using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InstructionScene : MonoBehaviour
{
    public Button PlayButton;
    public Button BackButton;


    // Start is called before the first frame update
    void Start()
    {
        
        PlayButton = GameObject.Find("Play Button").
                    GetComponent<Button>();
        PlayButton.onClick.AddListener(() => CharacterScene("Level 1"));
        BackButton = GameObject.Find("Back Button").
                    GetComponent<Button>();
        BackButton.onClick.AddListener(() => CharacterScene("Main"));
    }

    public void CharacterScene(string level)
    {
        SceneManager.LoadScene(level);
    }
}
