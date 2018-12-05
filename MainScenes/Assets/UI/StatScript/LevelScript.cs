using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScript : MonoBehaviour {

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
        Text lvltext = GameObject.Find("LevelText").GetComponent<Text>();
        lvltext.text = " " + characterStats.currentLevel.ToString();
    }
}
