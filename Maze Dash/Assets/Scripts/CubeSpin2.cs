using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpin2 : MonoBehaviour {

    float theta = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(2, 1, 3);
        transform.position = new Vector3(Mathf.Cos(theta), Mathf.Sin(theta), 0.0f);
        theta += 0.01f;

	}
}
