using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour
{
    public GameObject GrenadeBoulet;

    //Lance le boulet devant le canon
    public void LaunchProjectile(GameObject boulet)
    {
        //Si le boulet est une grenade, réduit ses chance d'apparaitre
        if(boulet == GrenadeBoulet)
        {
            float rand = Random.value;
            if (rand <= 0.3f)
            {
                Instantiate(boulet, new Vector3(transform.position.x, 0, transform.position.z), transform.rotation);
            }

        } else
        {
            Instantiate(boulet, new Vector3(transform.position.x, 0, transform.position.z), transform.rotation);
        }
        
        
    }
}
