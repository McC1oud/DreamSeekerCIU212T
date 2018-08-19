using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPivot : MonoBehaviour {

    bool panMovn = false;
    public float camPanSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxis("Horizontal2");

        print(x);
        if(x > 0.5f)
        {
            transform.Translate(Vector3.right * camPanSpeed * Time.deltaTime);
        }

        if (x < -0.5f)
        {
            transform.Translate(-Vector3.right * camPanSpeed * Time.deltaTime);
        }

        x = 0;

    }
}
