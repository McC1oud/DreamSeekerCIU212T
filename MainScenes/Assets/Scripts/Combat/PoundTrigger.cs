using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoundTrigger : MonoBehaviour {

    public int Damage { get; set; }
    CharacterStats myStats;
    public int dmgmulti;


    void Start()
    {
        myStats = GameObject.Find("Player").GetComponent<CharacterStats>();
        dmgmulti = 2;
        Damage = 50;
    }


    void Update()
    {


    }
    

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "enemy")
        {
            print("Pound Hit");
            // waiting = false;
            //rb.AddForce(other.contacts[0].normal * 1000);

            //Add script to deal damage to player here
            other.transform.GetComponent<CharacterStats>().TakeDamage(myStats.damage*dmgmulti, CritChance(), myStats.CriticalDamage);



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
