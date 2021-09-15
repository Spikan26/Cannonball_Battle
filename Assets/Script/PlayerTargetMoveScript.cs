using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTargetMoveScript : MonoBehaviour
{

    public GameObject limitSudOuest;
    public GameObject limitNordEst;

    // Update is called once per frame
    void Update()
    {

        //Moving Up
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Vector3 newPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 5);

            if(newPos.z < limitNordEst.transform.position.z)
            {
                transform.position = newPos;
            }
        }

        //Moving Left
        if (Input.GetKeyDown(KeyCode.D))
        {
            Vector3 newPos = new Vector3(transform.position.x + 5, transform.position.y, transform.position.z);

            if (newPos.x < limitNordEst.transform.position.x)
            {
                transform.position = newPos;
            }
        }

        //Moving Right
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Vector3 newPos = new Vector3(transform.position.x - 5, transform.position.y, transform.position.z);

            if (newPos.x > limitSudOuest.transform.position.x)
            {
                transform.position = newPos;
            }
        }

        //Moving Down
        if (Input.GetKeyDown(KeyCode.S))
        {
            Vector3 newPos = new Vector3(transform.position.x, transform.position.y, transform.position.z - 5);

            if (newPos.z > limitSudOuest.transform.position.z)
            {
                transform.position = newPos;
            }
        }
    }
}
