using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControls : MonoBehaviour {

    public float characterMoveSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        float _Vertz = Input.GetAxis("Vertical");
        float _Horiz = Input.GetAxis("Horizontal");

        transform.Translate(_Horiz * characterMoveSpeed, 0, _Vertz * characterMoveSpeed);

    }
}
