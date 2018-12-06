using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public int PlayerLevel;
	public int SkillPoints;
	// Use this for initialization
	void Start () 
	{
		PlayerLevel = 1;
		SkillPoints = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (Input.GetKeyDown(KeyCode.U))
		{
			// Check whether it's active / inactive
			LevelUp();
		}
	}
			
	void LevelUp()
	{
		PlayerLevel++;
		SkillPoints++;
		
		
	}
}
