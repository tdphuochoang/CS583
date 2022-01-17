using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
    //songelton
    private static GameManger _instance;
    public static GameManger Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }


    [SerializeField] float playerScore = 0;
    [SerializeField] float cannonBalls = 0;
    [SerializeField] Text playerScoreText;
    [SerializeField] Text cannonBallsText;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject WinMenu;
    [SerializeField] GameObject canvas;


    float Temp = 1000;
    float tempPlayerScore = 0;



    // Start is called before the first frame update
    void Start()
    {
        playerScoreText.text = "Score :" + playerScore.ToString();
        cannonBallsText.text = "Cannon Balls :" + cannonBalls.ToString();
        WinMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
        GetNumberOfDestructible();
    }

    private void GetNumberOfDestructible()
    {

        if (FindObjectsOfType<Destructible>().Length < 1 && FindObjectsOfType<PlayerController>().Length > 0)
        {
            WinMenu.SetActive(true);
        }
        else
        {
            WinMenu.SetActive(false);
        }
        if (FindObjectsOfType<PlayerController>().Length <= 0)
        {
            //disable canvas
            canvas.SetActive(false);
        }
        if (FindObjectsOfType<PlayerController>().Length > 0)
        {
            canvas.SetActive(true);
        }

    }

    public void AddScore(float points)
    {
        playerScore += points;
        playerScoreText.text = "Score : " + playerScore.ToString();

        if (playerScore >= Temp)
        {
            AddCannonBalls(2f);
            Temp += 1000;
        }

    }
    public void AddCannonBalls(float balls)
    {
        cannonBalls += balls;
        cannonBallsText.text = "Cannon Balls : " + cannonBalls.ToString();
    }
    public void UseCannonBalls()
    {
        cannonBalls -= 1f;
        if (cannonBalls < 0)
        {
            GameOver();
            cannonBalls = 10f;
        }
        cannonBallsText.text = "Cannon Balls : " + cannonBalls.ToString();

    }

    public void PauseGame()
    {
        if (pauseMenu.activeSelf)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        cannonBalls = 10f;
        cannonBallsText.text = "Cannon Balls : " + cannonBalls.ToString();
        playerScore = tempPlayerScore;
        playerScoreText.text = "Score : " + playerScore.ToString();
        PauseGame();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Main");
        WinMenu.SetActive(false);
        pauseMenu.SetActive(false);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        tempPlayerScore = playerScore;
        WinMenu.SetActive(false);
    }
    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

}
