using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTargetMoveScript : MonoBehaviour
{

    public GameObject limitSudOuest;
    public GameObject limitNordEst;

    public float movementCooldown;

    public void Start()
    {
        //Initialise le temps de récupération du déplacement
        movementCooldown = Time.time;
    }


    void Update()
    {
        //Si le joueur n'est pas en récupération de son déplacement précédent
        if(Time.time - 0.2f > movementCooldown)
        {
            //Moving Up
            if (Input.GetKeyDown(KeyCode.Z))
            {
                //Situe la prochaine destination
                Vector3 newPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 5);

                //Vérifie si le déplacement n'est pas en dehors de la zone
                if (newPos.z < limitNordEst.transform.position.z)
                {
                    transform.position = newPos;
                }

                //Active la récupération
                movementCooldown = Time.time;
            }

            //Moving Left
            if (Input.GetKeyDown(KeyCode.D))
            {
                Vector3 newPos = new Vector3(transform.position.x + 5, transform.position.y, transform.position.z);

                if (newPos.x < limitNordEst.transform.position.x)
                {
                    transform.position = newPos;
                }

                movementCooldown = Time.time;
            }

            //Moving Right
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Vector3 newPos = new Vector3(transform.position.x - 5, transform.position.y, transform.position.z);

                if (newPos.x > limitSudOuest.transform.position.x)
                {
                    transform.position = newPos;
                }

                movementCooldown = Time.time;
            }

            //Moving Down
            if (Input.GetKeyDown(KeyCode.S))
            {
                Vector3 newPos = new Vector3(transform.position.x, transform.position.y, transform.position.z - 5);

                if (newPos.z > limitSudOuest.transform.position.z)
                {
                    transform.position = newPos;
                }

                movementCooldown = Time.time;
            }
        }

    }

    //Input pour les joueurs mobile (swipe)
    public void MobileInput(SwipeData direction)
    {
        if(Time.time - 0.2f > movementCooldown)
        {
            //Moving Up
            if (direction.Direction.ToString() == "Up")
            {
                Vector3 newPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 5);

                if (newPos.z < limitNordEst.transform.position.z)
                {
                    transform.position = newPos;
                }

                movementCooldown = Time.time;

            }

            //Moving Left
            if (direction.Direction.ToString() == "Left")
            {
                Vector3 newPos = new Vector3(transform.position.x + 5, transform.position.y, transform.position.z);

                if (newPos.x < limitNordEst.transform.position.x)
                {
                    transform.position = newPos;
                }

                movementCooldown = Time.time;
            }

            //Moving Right
            if (direction.Direction.ToString() == "Right")
            {
                Vector3 newPos = new Vector3(transform.position.x - 5, transform.position.y, transform.position.z);

                if (newPos.x > limitSudOuest.transform.position.x)
                {
                    transform.position = newPos;
                }

                movementCooldown = Time.time;
            }

            //Moving Down
            if (direction.Direction.ToString() == "Down")
            {
                Vector3 newPos = new Vector3(transform.position.x, transform.position.y, transform.position.z - 5);

                if (newPos.z > limitSudOuest.transform.position.z)
                {
                    transform.position = newPos;
                }

                movementCooldown = Time.time;
            }
        }
        
        
    }


}
