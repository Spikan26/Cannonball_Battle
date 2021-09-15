using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouletScript : MonoBehaviour
{

    public int speed = 5;
    public bool isPiece;
    public bool isGrenade;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            if (isPiece)
            {
                //TODO: Ajouter score
                Destroy(gameObject);
            }
            else if (isGrenade)
            {
                GameObject[] allBoulet = GameObject.FindGameObjectsWithTag("Boulet");
                foreach (GameObject boulet in allBoulet)
                {
                    Destroy(boulet);
                }
                
            }
            else
            {
                Debug.Log("GAME OVER");
            }
        }
    }
}
