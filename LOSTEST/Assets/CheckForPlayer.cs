using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script runs the "On Trigger' events handling the enemy visual cone
//There are two seperate events passing a boolean to the same method in the AIScript.

public class CheckForPlayer : MonoBehaviour {

    public delegate void PlayerDetection(bool trigStatus);

    public static PlayerDetection detectionEnter;
    public static PlayerDetection detectionExit;

    public void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            
            detectionEnter(true);
            
        }
    }

    public void OnTriggerExit(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            
            detectionExit(false);
        }
    }
}
