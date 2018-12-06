using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCombat : MonoBehaviour {

    public bool endCombatA, endCombatB, endCombatC;

    public GameObject spawnerA, spawnerB, spawnerC;


	void Start () {
		if(spawnerA == null)
        {
            endCombatA = true;
        }
        else
        {
            endCombatA = false;
        }

        if (spawnerB == null)
        {
            endCombatB = true;
        }
        else
        {
            endCombatB = false;
        }

        if (spawnerC == null)
        {
            endCombatC = true;
        }
        else
        {
            endCombatC = false;
        }
    }


    void Update() {

        if (endCombatA && endCombatB && endCombatC)
        { 
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            Destroy(this);
        }
	}

}
