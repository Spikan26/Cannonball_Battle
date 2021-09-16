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
    }


    void Start()
    {
        score = 0;

        if (PlayerPrefs.HasKey("Vie")) { } else { PlayerPrefs.SetInt("Vie", 3); }
        if (PlayerPrefs.HasKey("VieMax")) { } else { PlayerPrefs.SetInt("VieMax", 3); }
        if (PlayerPrefs.HasKey("VieRegen")) { } else { PlayerPrefs.SetString("VieRegen", "false"); }
        if (PlayerPrefs.HasKey("VieRegenStart")) { } else { PlayerPrefs.SetString("VieRegenStart", ""); }
        if (PlayerPrefs.HasKey("Credit")) { PlayerPrefs.SetInt("Credit", 0); }

        vieMax = PlayerPrefs.GetInt("VieMax");
    }

    private void Update()
    {
        GestionVie();

    }

    public void TESToption()
    {
        Debug.Log("Vie MINUS");
        PlayerPrefs.SetInt("Vie", 2);
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
