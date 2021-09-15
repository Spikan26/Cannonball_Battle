using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour
{

    public void LaunchProjectile(GameObject boulet)
    {
        Instantiate(boulet, new Vector3(transform.position.x, 0, transform.position.z), transform.rotation);
    }
}
