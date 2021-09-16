using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour
{
    
    Renderer rend;
    public float waterSpeed = 0.1f;


    void Start()
    {
        //R�cup�re le composant Renderer de l'objet
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        //Vitesse de l'offset
        float offset = Time.time * waterSpeed;

        //Effectue un d�calage de la texture pour simuler l'�coulement de l'eau
        rend.material.SetTextureOffset("_MainTex", new Vector3(offset, offset, 0));
    }
}