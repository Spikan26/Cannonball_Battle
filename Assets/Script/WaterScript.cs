using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour
{
    Renderer rend;
    public float waterSpeed = 0.1f;


    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        float offset = Time.time * waterSpeed;

        rend.material.SetTextureOffset("_MainTex", new Vector3(offset, offset, 0));
    }
}