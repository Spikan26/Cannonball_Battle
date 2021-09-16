using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManagerGameOverScript : MonoBehaviour
{
    public Text scoreText;
    public Text highscoreText;
    public GameObject HighScoreStar;

    private int highscore = 0;


    void Awake()
    {
        GameObject gameManager = GameObject.FindGameObjectWithTag("GameManager");
        int newscore = gameManager.GetComponent<GameManagerScript>().score;

        scoreText.text = "Score : " + newscore.ToString();

        if (PlayerPrefs.HasKey("HighScore"))
        {
            highscore = PlayerPrefs.GetInt("HighScore");
            highscoreText.text = "Highscore : " + highscore;
        }

        if (newscore > highscore)
        {
            highscoreText.text = "Highscore : " + newscore;
            HighScoreStar.SetActive(true);
            gameManager.GetComponent<GameManagerScript>().NewHighScore(newscore);
        }

        int credit = PlayerPrefs.GetInt("Credit");
        credit += newscore / 10;
        PlayerPrefs.SetInt("Credit", credit);

        gameManager.GetComponent<GameManagerScript>().ResetScore();
    }
}
