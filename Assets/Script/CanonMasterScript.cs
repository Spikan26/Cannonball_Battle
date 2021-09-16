using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonMasterScript : MonoBehaviour
{

    public List<GameObject> typeBoulet;
    public List<GameObject> listCannon;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("LaunchProjectile", 2.0f, 0.3f);
    }

    void LaunchProjectile()
    {
        int cannonIndex = Random.Range(0,listCannon.Count);
        int bouletIndex = Random.Range(0,typeBoulet.Count);
        listCannon[cannonIndex].GetComponent<CannonScript>().LaunchProjectile(typeBoulet[bouletIndex]);
    }

}
