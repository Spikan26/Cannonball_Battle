using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public int score;
    public int vie;
    public int credit;
    public int vieMax;
    public System.DateTime vieTimer;


    void Awake()
    {
        //Permet de garder l'objet entre les scènes.
        DontDestroyOnLoad(this.gameObject);

        //Vérifie si les clé existe, sinon les crées
        if (PlayerPrefs.HasKey("Vie")) { } else { PlayerPrefs.SetInt("Vie", 3); }
        if (PlayerPrefs.HasKey("VieMax")) { } else { PlayerPrefs.SetInt("VieMax", 3); }
        if (PlayerPrefs.HasKey("VieRegenStart")) { } else { PlayerPrefs.SetString("VieRegenStart", ""); }
        if (PlayerPrefs.HasKey("Credit")) { } else { PlayerPrefs.SetInt("Credit", 0); }

        //Récupère les données
        score = 0;
        vie = PlayerPrefs.GetInt("Vie");
        credit = PlayerPrefs.GetInt("Credit");
        vieMax = PlayerPrefs.GetInt("VieMax");

    }

    private void Update()
    {
        GestionVie();
        credit = PlayerPrefs.GetInt("Credit");
    }

    //Gestion de la Vie et de sa Regénération
    public void GestionVie()
    {
        //Récupère le nombre de vie actuel
        vie = PlayerPrefs.GetInt("Vie");

        //Si le nombre de vie n'est pas au maximum
        if (vie < vieMax)
        {
            //Si la regeneration n'a pas commencé
            if (PlayerPrefs.GetString("VieRegenStart") == "")
            {
                //Récupère le moment de départ de la regénération
                PlayerPrefs.SetString("VieRegenStart", System.DateTime.Now.ToString());
            } 
            
            vieTimer = System.DateTime.Parse(PlayerPrefs.GetString("VieRegenStart"));
            
            //Si le temps de récupération est passé (1 minute pour les tests)
            if (System.DateTime.Now.AddMinutes(-1) > vieTimer)
            {
                //Rajout d'une vie
                vie++;
                PlayerPrefs.SetInt("Vie", vie);

                //Si la vie n'est toujours pas au maximum
                if (vie++ < vieMax)
                {
                    //Récupère de nouveau le moment de départ de la regénération
                    PlayerPrefs.SetString("VieRegenStart", System.DateTime.Now.ToString());
                }
                else
                {
                    //Sinon, efface la donnée
                    PlayerPrefs.SetString("VieRegenStart", "");
                }
            }
        }
    }

    //Ajoute les points au score
    public void AddScore(int point)
    {
        score += point;
    }

    //Remet le score à Zero
    public void ResetScore()
    {
        score = 0;
    }

    //Enregistre le nouveau HighScore
    public void NewHighScore(int newscore)
    {
        PlayerPrefs.SetInt("HighScore", newscore);
    }

    //Lance la partie si le nombre de vie est suffisant
    public void LaunchGame()
    {
        int vie = PlayerPrefs.GetInt("Vie");
        if (vie > 0)
        {
            GameObject sceneChanger = GameObject.FindGameObjectWithTag("SceneChanger");
            sceneChanger.GetComponent<SceneChangerScript>().ChangeScene("Game");
        }
        
    }
}
