using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool gameStarted;
    public int score;
    public Text scoreText;
    public Text highScoreText;


    private void Awake()
    {
        highScoreText.text = "Best: " + getHighscore().ToString();
    }

    public void Startgame()
    {
        gameStarted = true;
        FindObjectOfType<Road>().StartBuilding();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Startgame();
        }
    }

    public void EndGame()
    {
        SceneManager.LoadScene(0);
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();

        if (score > getHighscore())
        {
            PlayerPrefs.SetInt("Highscore", score);
            highScoreText.text = "Best: " + score.ToString();
        }

    }
    public int getHighscore()
    {
        int i = PlayerPrefs.GetInt("Highscore");
        return i;
    }

}
