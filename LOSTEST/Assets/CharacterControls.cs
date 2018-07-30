using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControls : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("w"))
        {
            transform.Translate(0,0,0.2f);
        }

        if (Input.GetKey("s"))
        {
            transform.Translate(0, 0, -0.2f);
        }

        if (Input.GetKey("a"))
        {
            transform.Translate(-0.2f, 0, 0);
        }

        if (Input.GetKey("d"))
        {
            transform.Translate(0.2f, 0, 0);
        }
    }
}
