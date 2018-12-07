using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchTrigger : MonoBehaviour {

    public int Damage { get; set; }
    CharacterStats myStats;

    public int energyrestore = 5;

    // Use this for initialization
    void Start ()
    {
        
        myStats = GetComponentInParent<CharacterStats>();
        // Need to reference damage from player 
		Damage = 5;
	}
	
	// Update is called once per frame
	void Update ()
    {

        // Destroy(this.gameObject, 1f);
	}

    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.transform.tag == "enemy")
    //    {
    //        Debug.Log(Damage + " DamageDealt to " + collision.transform.name);
    //        print(Damage + " DamageDealt to " + collision.transform.name);
    //        collision.transform.GetComponent<CharacterStats>().TakeDamage(Damage);
    //    }
    //    else
    //    {
    //        Debug.Log("Nani?");
    //    }
    //    Debug.Log("HIT");

    //}

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "enemy")
        {
            print("Punch Hit");

           

            //Add script to deal damage to player here
            other.transform.GetComponent<CharacterStats>().TakeDamage(myStats.damage,CritChance(), myStats.CriticalDamage);
            myStats.currentEnergy += energyrestore;
            Debug.Log(myStats.name + " " + energyrestore +".");

            // Destroy(this.gameObject);

        }
    }

    bool CritChance()
    {
        // Chance of critting hard coded to 50%
        // create formula to increase critcal chance based on stats
        int criticalchance = Random.Range(0, 100);
        if (criticalchance < myStats.CriticalRate)
            return true;
        // else
        return false;
    }
}
