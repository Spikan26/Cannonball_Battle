using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManagerMenuScript : MonoBehaviour
{
    public Text vieText;
    public Text vieShopText;
    public Text creditText;
    public Text creditShopText;


    public void Awake()
    {
        
    }

    void Update()
    {
        GameObject gameManager = GameObject.FindGameObjectWithTag("GameManager");

        int vie = gameManager.GetComponent<GameManagerScript>().vie;
        int vieMax = gameManager.GetComponent<GameManagerScript>().vieMax;
        int credit = gameManager.GetComponent<GameManagerScript>().credit;

        vieText.text = "Vie : " + vie.ToString() + " / " + vieMax.ToString();
        vieShopText.text = "Vie : " + vie.ToString() + " / " + vieMax.ToString();
        creditText.text = "Credit : " + credit.ToString();
        creditShopText.text = "Credit : " + credit.ToString();
    }
}
