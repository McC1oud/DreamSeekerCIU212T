﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    AudioSource testSound;

	// Use this for initialization
	void Start ()
    {
        testSound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            testSound.Play();
        }
	}
}
