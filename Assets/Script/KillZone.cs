using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    //Lorsqu'un objet sors de la zone, le d�truit
    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }


}
