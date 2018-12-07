using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TotalSkill : MonoBehaviour {

    CharacterStats myStats;
    public Text skilltext;
    public int points;
	// Use this for initialization
	void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
        skilltext = GameObject.Find("TotalPoints").GetComponent<Text>();
        points = GameObject.Find("Player").GetComponent<CharacterStats>().skillPoints;
        skilltext.text = points.ToString();
    }
}
