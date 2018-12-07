using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickTrigger : MonoBehaviour {

    public int Damage { get; set; }
    CharacterStats myStats;
    public int knockback;

    public int energyrestore = 10;

    void Start()
    {

        myStats = GameObject.Find("Player").GetComponent<CharacterStats>();
        knockback = 20;
        Damage = 10;
    }

   
    void Update()
    {

        
    }

    

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "enemy")
        {
            print("Kick Hit");
            // waiting = false;
            //rb.AddForce(other.contacts[0].normal * 1000);

            //Add script to deal damage to player here
            other.transform.GetComponent<CharacterStats>().TakeDamage(Mathf.RoundToInt(myStats.damage*1.5f),CritChance(), myStats.CriticalDamage);
            myStats.currentEnergy += energyrestore;
            Debug.Log(myStats.name + " gained 10 energy.");
            

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
