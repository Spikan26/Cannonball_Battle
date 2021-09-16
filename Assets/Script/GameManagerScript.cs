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
        //Permet de garder l'objet entre les sc�nes.
        DontDestroyOnLoad(this.gameObject);

        //V�rifie si les cl� existe, sinon les cr�es
        if (PlayerPrefs.HasKey("Vie")) { } else { PlayerPrefs.SetInt("Vie", 3); }
        if (PlayerPrefs.HasKey("VieMax")) { } else { PlayerPrefs.SetInt("VieMax", 3); }
        if (PlayerPrefs.HasKey("VieRegenStart")) { } else { PlayerPrefs.SetString("VieRegenStart", ""); }
        if (PlayerPrefs.HasKey("Credit")) { } else { PlayerPrefs.SetInt("Credit", 0); }

        //R�cup�re les donn�es
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

    //Gestion de la Vie et de sa Reg�n�ration
    public void GestionVie()
    {
        //R�cup�re le nombre de vie actuel
        vie = PlayerPrefs.GetInt("Vie");

        //Si le nombre de vie n'est pas au maximum
        if (vie < vieMax)
        {
            //Si la regeneration n'a pas commenc�
            if (PlayerPrefs.GetString("VieRegenStart") == "")
            {
                //R�cup�re le moment de d�part de la reg�n�ration
                PlayerPrefs.SetString("VieRegenStart", System.DateTime.Now.ToString());
            } 
            
            vieTimer = System.DateTime.Parse(PlayerPrefs.GetString("VieRegenStart"));
            
            //Si le temps de r�cup�ration est pass� (1 minute pour les tests)
            if (System.DateTime.Now.AddMinutes(-1) > vieTimer)
            {
                //Rajout d'une vie
                vie++;
                PlayerPrefs.SetInt("Vie", vie);

                //Si la vie n'est toujours pas au maximum
                if (vie++ < vieMax)
                {
                    //R�cup�re de nouveau le moment de d�part de la reg�n�ration
                    PlayerPrefs.SetString("VieRegenStart", System.DateTime.Now.ToString());
                }
                else
                {
                    //Sinon, efface la donn�e
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

    //Remet le score � Zero
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
