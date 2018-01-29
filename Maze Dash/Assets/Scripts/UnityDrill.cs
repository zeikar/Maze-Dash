using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityDrill : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            transform.Translate(0f, -0.001f, 0f);
            transform.Rotate(0f, 10f, 0f);
        }
    }
}
