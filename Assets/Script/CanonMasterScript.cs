using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonMasterScript : MonoBehaviour
{

    public List<GameObject> typeBoulet;
    public List<GameObject> listCannon;

    public float cooldown = 5.0f;
    float nextUpdate;

    // Start is called before the first frame update
    void Start()
    {
        nextUpdate = Time.time + cooldown;
        InvokeRepeating("LaunchProjectile", 2.0f, 0.3f);
    }

    void LaunchProjectile()
    {
        int cannonIndex = Random.Range(0,listCannon.Count);
        int bouletIndex = Random.Range(0,typeBoulet.Count);
        listCannon[cannonIndex].GetComponent<CannonScript>().LaunchProjectile(typeBoulet[bouletIndex]);
    }

        // Update is called once per frame
    void Update()
    {

        if (nextUpdate < Time.time)
        {
            //Debug.Log("Update!");
            nextUpdate = Time.time + cooldown;
        }
    }
}
