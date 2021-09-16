using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{

    public GameObject MenuCanva;
    public GameObject ShopCanva;


    public void ShowShop()
    {
        ShopCanva.SetActive(true);
        MenuCanva.SetActive(false);
    }

    public void HideShop()
    {
        ShopCanva.SetActive(false);
        MenuCanva.SetActive(true);
    }


    public void AchatVie(int cost)
    {
        int credit = PlayerPrefs.GetInt("Credit");
        int vie = PlayerPrefs.GetInt("Vie");
        int vieMax = PlayerPrefs.GetInt("VieMax");

        if(vie < vieMax && credit > cost)
        {
            vie++;
            credit -= cost;
            PlayerPrefs.SetInt("Vie", vie);
            PlayerPrefs.SetInt("Credit", credit);
        }
    }

}
