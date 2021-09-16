using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour
{
    
    Renderer rend;
    public float waterSpeed = 0.1f;


    void Start()
    {
        //Récupère le composant Renderer de l'objet
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        //Vitesse de l'offset
        float offset = Time.time * waterSpeed;

        //Effectue un décalage de la texture pour simuler l'écoulement de l'eau
        rend.material.SetTextureOffset("_MainTex", new Vector3(offset, offset, 0));
    }
}