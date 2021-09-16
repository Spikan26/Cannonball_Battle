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
        //R�cup�re le GameManager
        GameObject gameManager = GameObject.FindGameObjectWithTag("GameManager");
        //R�cup�re le score de la partie
        int newscore = gameManager.GetComponent<GameManagerScript>().score;

        //Modifie le texte du score
        scoreText.text = "Score : " + newscore.ToString();

        //Test si la cl� des HighScore existe
        if (PlayerPrefs.HasKey("HighScore"))
        {
            //R�cup�re les HighScore et change le texte
            highscore = PlayerPrefs.GetInt("HighScore");
            highscoreText.text = "Highscore : " + highscore;
        }

        //Si le nouveau score est un HighScore
        if (newscore > highscore)
        {
            //Modifie le texte des HighScore
            highscoreText.text = "Highscore : " + newscore;
            //Fait apparaitre une �toile
            HighScoreStar.SetActive(true);
            //Enregistre le nouveau HighScore
            gameManager.GetComponent<GameManagerScript>().NewHighScore(newscore);
        }

        //Ajoute les cr�dit gagn�s
        int credit = PlayerPrefs.GetInt("Credit");
        credit += newscore / 10;
        PlayerPrefs.SetInt("Credit", credit);
        gameManager.GetComponent<GameManagerScript>().credit += credit;
        
        //Reset le score
        gameManager.GetComponent<GameManagerScript>().ResetScore();
    }
}
