using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour 
{
	public bool GameIsPaused = false;
	public GameObject mainMenu;
    public GameObject TigerM;
    public GameObject DragonM;
    public GameObject SakuraM;
    public GameObject OptionM;
    public GameObject UIButtons;
    public PlayerController playercontrol;

    // Update is called once per frame
    void Update () 
	{
       
		// Reverse the active state every time escape is pressed
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			if (GameIsPaused)
			{	
			//Closes
			CloseMenu ();
			}else 
			{
				//Opens the Menu
				Pause ();
			}
			// Check whether it's active / inactive
			//bool isActive = optionsMenu.activeSelf;
			//optionsMenu.SetActive(!isActive);
		} 

		if (Input.GetKeyDown(KeyCode.T))
		{
            // CLoses the menu
            CloseMenu();
		}
	}

	void Resume()
	{
        UIButtons.SetActive(false);
		mainMenu.SetActive (false);
		GameIsPaused = false;
        Time.timeScale = 1;
    }

	void Pause()
	{
        UIButtons.SetActive(true);
		mainMenu.SetActive (true);
		GameIsPaused = true;
        Time.timeScale = 0;
	}	
	public void CloseMenu()
	{
        UIButtons.SetActive(false);
        TigerM.SetActive(false);
        DragonM.SetActive(false);
        SakuraM.SetActive(false);
        OptionM.SetActive(false);
        mainMenu.SetActive (false);
		GameIsPaused = false;
        Time.timeScale = 1;
	}

    /// Make a separate script for each skill
	public void ActivateSkill()
	{
		int points = GameObject.Find ("Player").GetComponent<CharacterStats>().skillPoints;

		if (points >= 3)
        {
			Text skilltext = GameObject.Find ("SkillText").GetComponent<Text> ();
			skilltext.text = "Skill Activated";
			points = points - 3;
            GameObject.Find("Player").GetComponent<CharacterStats>().skillPoints -= 3;
        }
		print (points);

	}

    public void OpenTiger()
    {
        var tempColor = TigerM.GetComponent<Image>().color;
        tempColor.a = 0f;
        TigerM.GetComponent<Image>().color = tempColor;

        TigerM.SetActive(true);
        DragonM.SetActive(false);
        SakuraM.SetActive(false);
        OptionM.SetActive(false);
        mainMenu.SetActive(false);

        //this.gameObject.GetComponent<Image>().color = Color.red;
    }

    public void OpenDragon()
    {
        TigerM.SetActive(false);
        DragonM.SetActive(true);
        SakuraM.SetActive(false);
        OptionM.SetActive(false);
        mainMenu.SetActive(false);
    }

    public void OpenSakura()
    {
        TigerM.SetActive(false);
        DragonM.SetActive(false);
        SakuraM.SetActive(true);
        OptionM.SetActive(false);
        mainMenu.SetActive(false);
    }

    public void OpenOption()
    {
        TigerM.SetActive(false);
        DragonM.SetActive(false);
        SakuraM.SetActive(false);
        OptionM.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void OpenMain()
    {
        TigerM.SetActive(false);
        DragonM.SetActive(false);
        SakuraM.SetActive(false);
        OptionM.SetActive(false);
        mainMenu.SetActive(true);
    }
}



