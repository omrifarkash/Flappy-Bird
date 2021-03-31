using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bg : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = transform.position.x;
        bool check = x > -180.5f;
        if(check) transform.position = transform.position + new Vector3(-20f * Time.deltaTime, 0, 0);
        else transform.position = new Vector3(0, 0, 1);
    }
}
