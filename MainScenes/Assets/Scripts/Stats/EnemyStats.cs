using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    

    CharacterStats myStats;

    private void Awake()
    {
        myStats = GetComponent<CharacterStats>();
    }

    // Not working from here. Using Enemy cs update to kill enemy atm
    public override void Die()
    {
        
        // Remove on Enemy Stats if this is the death method
        if (myStats.currentHealth <= 0)
        {

            //Add Death Animation// Turning to blob of ink

            Destroy(gameObject, 1);

            //Add random loot maybe? Or spawn health recover item
        }

        //Add Death Animation// Turning to blob of ink

      

        //Add random loot maybe? Or spawn health recover item
    }

}
