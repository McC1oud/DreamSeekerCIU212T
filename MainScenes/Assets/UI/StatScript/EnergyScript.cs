using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyScript : MonoBehaviour {

    public CharacterStats characterStats;
    // Use this for initialization
    void Start()
    {
        characterStats = GameObject.Find("Player").GetComponent<CharacterStats>();
    }

    // Update is called once per frame
    void Update()
    {
        Text healthtext = GameObject.Find("EnergyText").GetComponent<Text>();
        healthtext.text = " " + characterStats.currentEnergy.ToString() + " / " + characterStats.maxEnergy.ToString();
    }
}
