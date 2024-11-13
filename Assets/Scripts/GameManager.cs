using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI restartText;
    public TextMeshProUGUI p1ScoreText;
    public TextMeshProUGUI p2ScoreText;
    public GameObject titleScreen;
    public bool isGameActive;
    public bool gameOver;
    private int lives;

    public PlayerMovement p1;
    public PlayerMovement p2;
    public int p1Score;
    public int p2Score;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        p1  = GameObject.Find("player 1").GetComponent<PlayerMovement>();
        p2  = GameObject.Find("player 2").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        // Press enter to start game
        if (Input.GetKeyDown("return")&&isGameActive==false&&gameOver==false)
        {
            Debug.Log("A");
            StartGame();
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }

        RestartGame();

        if (isGameActive == true)
        {
            p1Score=p1.getScore();
            p2Score=p2.getScore();
        }

        UpdateScore();
    }

    // Start game, disable title screen, and set lives to 5
    public void StartGame()
    {
        isGameActive = true;
        gameOver = false;
        lives = 5;

        titleScreen.gameObject.SetActive(false);
        livesText.text = "Lives: " + lives;
    }

    // Update amount of lives, and trigger game over if lives == 0
    public void UpdateLives()
    {
        if (isGameActive)
        {
            lives--;
            livesText.text = "Lives: " + lives;
            if (lives == 0)
            {
                GameOver();
            }
        }
    }

    public void UpdateScore()
    {
        p1ScoreText.text = "Score: " + p1Score;
        p2ScoreText.text = "Score: " + p2Score;
    }

    public void GameOver()
    {
        restartText.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        gameOver = true;
    }

    public void RestartGame()
    {
        if (Input.GetKeyDown("return") && gameOver == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}