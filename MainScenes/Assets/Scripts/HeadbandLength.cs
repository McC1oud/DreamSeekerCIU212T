using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadbandLength : MonoBehaviour
{
    Vector3 headband;
    CharacterStats myStats;
    public float curHealth;
    public float maxHealth;

	// Use this for initialization
	void Start ()
    {
        myStats = GetComponentInParent<CharacterStats>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        headband = transform.localScale;

        curHealth = myStats.currentHealth;

        maxHealth = myStats.maxHealth;

        headband.z = (curHealth/maxHealth) ;

        

        transform.localScale = headband;



        

        if (Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log(headband);
            headband.z += .5f;

            transform.localScale = headband;

            Debug.Log(headband);
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log(curHealth);
            headband.z -= .5f;

            transform.localScale = headband;
        }

    }
}
