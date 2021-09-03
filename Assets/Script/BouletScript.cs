using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouletScript : MonoBehaviour
{

    public int speed = 3;
        
    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
        Debug.Log("Coucou");
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        speed += 1;
    }
 
    void CheckInput()
    {

    }

}
