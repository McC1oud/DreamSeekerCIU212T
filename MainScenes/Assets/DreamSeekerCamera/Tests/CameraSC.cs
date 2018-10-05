using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSC : MonoBehaviour {

    private float speed = 0.0f;
    private float h, v = 0.0f;

	void Start () {
		
	}
	
	
	void Update () {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        speed = new Vector2(h, v).sqrMagnitude;
    }
}
