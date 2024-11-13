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
    private int lives;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Press enter to start game
        if (Input.GetKeyDown("return")&&isGameActive==false)
        {
            Debug.Log("A");
            StartGame();
        }
    }

    // Start game, disable title screen, and set lives to 5
    public void StartGame()
    {
        isGameActive = true;
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
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}