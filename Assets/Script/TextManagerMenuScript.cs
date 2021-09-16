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

    int vie;
    int vieMax;
    int credit;
        

    void Update()
    {
        //Récupère le GameManager
        GameObject gameManager = GameObject.FindGameObjectWithTag("GameManager");

        //Stock les variables du GameManager
        vie = gameManager.GetComponent<GameManagerScript>().vie;
        vieMax = gameManager.GetComponent<GameManagerScript>().vieMax;
        credit = gameManager.GetComponent<GameManagerScript>().credit;

        //Modifie les différents texte des menus (variable vie et credit)
        vieText.text = "Vie : " + vie.ToString() + " / " + vieMax.ToString();
        vieShopText.text = "Vie : " + vie.ToString() + " / " + vieMax.ToString();
        creditText.text = "Credit : " + credit.ToString();
        creditShopText.text = "Credit : " + credit.ToString();
    }
}
