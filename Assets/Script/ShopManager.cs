using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{

    public GameObject MenuCanva;
    public GameObject ShopCanva;

    //Affiche le Shop
    public void ShowShop()
    {
        ShopCanva.SetActive(true);
        MenuCanva.SetActive(false);
    }

    //Cache le Shop
    public void HideShop()
    {
        ShopCanva.SetActive(false);
        MenuCanva.SetActive(true);
    }

    //Methode pour acheter de la vie
    public void AchatVie(int cost)
    {
        //R�cup�re les donn�es
        int credit = PlayerPrefs.GetInt("Credit");
        int vie = PlayerPrefs.GetInt("Vie");
        int vieMax = PlayerPrefs.GetInt("VieMax");

        //Si l'achat est possible, ach�te l'objet pour son co�t
        if(vie < vieMax && credit > cost)
        {
            vie++;
            credit -= cost;
            PlayerPrefs.SetInt("Vie", vie);
            PlayerPrefs.SetInt("Credit", credit);
        }
    }

}
