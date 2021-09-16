using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouletScript : MonoBehaviour
{
    public int speed = 5;
    public bool isPiece;
    public bool isGrenade;

    //D�place le boulet en avant
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        //En cas de collision avec le joueur
        if (other.transform.tag == "Player")
        {
            //Si le boulet est une pi�ce
            if (isPiece)
            {
                //Ajoute des points au score et d�truit le boulet
                GameObject gameManager = GameObject.FindGameObjectWithTag("GameManager");
                gameManager.GetComponent<GameManagerScript>().AddScore(10);
                Destroy(gameObject);
            }
            //Si le boulet est une grenade
            else if (isGrenade)
            {
                //R�cup�re la liste des boulets pr�sent dans la sc�ne et les d�truits
                GameObject[] allBoulet = GameObject.FindGameObjectsWithTag("Boulet");
                foreach (GameObject boulet in allBoulet)
                {
                    Destroy(boulet);
                }
                
            }
            //Si le boulet est un boulet n�gatif
            else
            {
                //Retire une vie au joueur
                int vie = PlayerPrefs.GetInt("Vie");
                vie--;
                PlayerPrefs.SetInt("Vie", vie);

                //Change la sc�ne pour afficher le gameover
                GameObject sceneChanger = GameObject.FindGameObjectWithTag("SceneChanger");
                sceneChanger.GetComponent<SceneChangerScript>().ChangeScene("GameOver");
            }
        }
    }
}
