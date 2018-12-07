using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeAtk : MonoBehaviour {

	// Use this for initialization
	CharacterStats myStats;
	public int Damage;

	// Use this for initialization
	void Start ()
	{

		myStats = GetComponentInParent<CharacterStats>();
		// Need to reference damage from player 
		Damage = 15;
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
		Debug.Log ("BAM!!!!!");
		if (other.transform.tag == "player")
		{
			print(other.transform.name + " takes " + Damage + ".");



			//Add script to deal damage to player here
			other.transform.GetComponent<CharacterStats>().TakeDamage(Damage,CritChance(),myStats.CriticalDamage);



			// Destroy(this.gameObject);

		}
	}

    bool CritChance()
    {
        // Chance of critting hard coded to 50%
        // create formula to increase critcal chance based on stats
        int criticalchance = Random.Range(0, 100);
        if (criticalchance < 50)
            return true;
        // else
        return false;
    }
}
