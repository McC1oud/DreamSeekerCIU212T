using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactable
{
    PlayerManager playerManager;
    CharacterStats myStats;
    public int experienceValue;

    void Start()
    {
        playerManager = PlayerManager.instance;
        myStats = GetComponent<CharacterStats>();
    }

    public override void Interact()
    {

        base.Interact();
        // Attack the enemy
        CharacterCombat playerCombat = playerManager.player.GetComponent<CharacterCombat>();

        if (playerCombat != null)
        {
            playerCombat.Attack(myStats);
        }

    }

    void Update()
    {
        // Remove on Enemy Stats if this is the death method
        if (myStats.currentHealth <= 0)
        {

            //Add Death Animation// Turning to blob of ink
            GiveExp();
            Destroy(gameObject);

            //Add random loot maybe? Or spawn health recover item
        }
    }

    void GiveExp()
    {
        playerManager.player.GetComponent<CharacterStats>().currentExperience += experienceValue;
    }
}
