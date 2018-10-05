using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// This script is currently doesnt do anything
public class PlayerStats : CharacterStats
{
    
    // Should contain code for referencing the tattoos to alter stats
	// Use this for initialization
	void Start ()
    {
        //Tattoo equiping
        //TattooManager.instance.onTattooChange +- OnTattooChanged;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //void OnTattooChanged (Tattoo newTattoo, Tattoo oldTattoo)
    //{
    //      if (newTattoo != null)
    //      {
    //      defense.AddModifier(newTattoo.defenseModifier);
    //      damage.AddModifier(newTattoo.damageModifier);
    //}
    //{
    //      if (oldTattoo != null)
    //      {
    //      defense.RemoveModifier(newTattoo.defenseModifier);
    //      damage.RemovieModifier(newTattoo.damageModifier);
    //}

    public override void Die()
    {
        base.Die();
        // Play death animation // Call up Game Over screen
        PlayerManager.instance.KillPlayer();
    }

}
