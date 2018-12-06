using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillArray : MonoBehaviour {

    public GameObject playerArray;

	public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "enemy")
        {
            playerArray.GetComponent<PlayerController>().nearbyEnemyList.Add(other.gameObject);
        }
    }
}
