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
        DontDestroyOnLoad(this.gameObject);

        if (PlayerPrefs.HasKey("Vie")) { } else { PlayerPrefs.SetInt("Vie", 3); }
        if (PlayerPrefs.HasKey("VieMax")) { } else { PlayerPrefs.SetInt("VieMax", 3); }
        if (PlayerPrefs.HasKey("VieRegenStart")) { } else { PlayerPrefs.SetString("VieRegenStart", ""); }
        if (PlayerPrefs.HasKey("Credit")) { PlayerPrefs.SetInt("Credit", 0); }

        score = 0;
        vie = PlayerPrefs.GetInt("Vie");
        credit = PlayerPrefs.GetInt("Credit");
        vieMax = PlayerPrefs.GetInt("VieMax");

    }


    void Start()
    {
        
    }

    private void Update()
    {
        GestionVie();
        credit = PlayerPrefs.GetInt("Credit");
    }

    public void GestionVie()
    {
        vie = PlayerPrefs.GetInt("Vie");

        if (vie < vieMax)
        {
            
            if (PlayerPrefs.GetString("VieRegenStart") == "")
            {
                PlayerPrefs.SetString("VieRegenStart", System.DateTime.Now.ToString());
            } 
            
            vieTimer = System.DateTime.Parse(PlayerPrefs.GetString("VieRegenStart"));
            
            
            if (System.DateTime.Now.AddMinutes(-1) > vieTimer)
            {
                vie++;
                PlayerPrefs.SetInt("Vie", vie);
                Debug.Log("Vie récupéré !");
                if (vie++ < vieMax)
                {
                    PlayerPrefs.SetString("VieRegenStart", System.DateTime.Now.ToString());
                }
                else
                {
                    PlayerPrefs.SetString("VieRegenStart", "");
                }
            }
        }
    }

    public void AddScore(int point)
    {
        score += point;
    }

    public void ResetScore()
    {
        score = 0;
    }

    public void NewHighScore(int newscore)
    {
        PlayerPrefs.SetInt("HighScore", newscore);
    }

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
