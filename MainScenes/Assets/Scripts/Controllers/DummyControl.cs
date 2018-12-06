using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyControl : MonoBehaviour 
{
    CharacterStats dummyStats;
	// Use this for initialization
	void Start () {
        dummyStats = GetComponent<CharacterStats>();
	}
	
	// Update is called once per frame
	void Update () {

        if (dummyStats.currentHealth < dummyStats.maxHealth/2)
        {
            Debug.Log("DummyHeal!");
            dummyStats.currentHealth += dummyStats.maxHealth;
            
        }
		
	}
}
