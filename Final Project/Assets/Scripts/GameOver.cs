using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Button Replay;
    public Button Main;

    // Start is called before the first frame update
    void Start()
    {
//        BackGroundMusic.Instance.gameObject.GetComponent<AudioSource>().Pause();
        Replay = GameObject.Find("Replay Button").
            GetComponent<Button>();
        Replay.onClick.AddListener(() => CharacterScene("Level 1"));
        Main = GameObject.Find("Main Button").
            GetComponent<Button>();
        Main.onClick.AddListener(() => CharacterScene("Main"));

    }

    public void CharacterScene(string level)
    {
        SceneManager.LoadScene(level);
    }
}
