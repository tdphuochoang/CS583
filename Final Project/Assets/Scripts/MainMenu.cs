using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button PlayButton;
    public Button QuitButton;
    public Button CreditButton;
    // Start is called before the first frame update
    void Start()
    {
        if(!BackGroundMusic.Instance.gameObject.GetComponent<AudioSource>().isPlaying)
            BackGroundMusic.Instance.gameObject.GetComponent<AudioSource>().Play();
        PlayButton = GameObject.Find("Play Button").
            GetComponent<Button>();
        PlayButton.onClick.AddListener(() => CharacterScene("Instruction"));
        CreditButton = GameObject.Find("Credit Button").
            GetComponent<Button>();
        CreditButton.onClick.AddListener(() => CharacterScene("Credit"));
        QuitButton = GameObject.Find("Quit Button").
            GetComponent<Button>();
        QuitButton.onClick.AddListener(() => Quit());

    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void CharacterScene(string level)
    {
        SceneManager.LoadScene(level);
    }
}
