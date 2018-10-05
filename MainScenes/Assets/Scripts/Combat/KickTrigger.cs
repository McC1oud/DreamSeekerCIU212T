using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickTrigger : MonoBehaviour {

    public int Damage { get; set; }
    CharacterStats myStats;
    public int knockback;
    
    
    void Start()
    {

        myStats = GetComponentInParent<CharacterStats>();
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
            other.transform.GetComponent<CharacterStats>().TakeDamage(Damage);
            myStats.currentEnergy += 10;
            Debug.Log(myStats.name + " gained 10 energy.");
            

            // Destroy(this.gameObject);

        }
    }
}
