using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatArena : MonoBehaviour {


   public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "player")
        {
            print("walled");
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(this);
        }
    }
}
