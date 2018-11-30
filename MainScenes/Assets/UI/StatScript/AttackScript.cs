using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackScript : MonoBehaviour {

    // Use this for initialization
    public CharacterStats characterStats;
    // Use this for initialization
    void Start()
    {
        characterStats = GameObject.Find("Player").GetComponent<CharacterStats>();
    }

    // Update is called once per frame
    void Update()
    {
        Text healthtext = GameObject.Find("AttackText").GetComponent<Text>();
        healthtext.text = " " + characterStats.damage.GetValue().ToString();
    }
}
