using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditScene : MonoBehaviour
{
    public Button BackButton;

    // Start is called before the first frame update
    void Start()
    {
        BackButton = GameObject.Find("Back Button").
                    GetComponent<Button>();
        BackButton.onClick.AddListener(() => CharacterScene("Main"));
    }

    public void CharacterScene(string level)
    {
        SceneManager.LoadScene(level);
    }
}
