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
    public GameObject titleScreen;
    public bool isGameActive;
    public bool gameOver;
    private int lives;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
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