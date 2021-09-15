using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public GameObject targetPos;

    void Update()
    {
            Vector3 newPos = new Vector3(targetPos.transform.position.x, 0, targetPos.transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * 20);
    }
}
