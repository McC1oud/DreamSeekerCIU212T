using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SakuraSkills : MonoBehaviour {

    CharacterStats myStats;

    public GameObject skill;
    public GameObject skill1;
    public GameObject skill2;
    public GameObject skill3;

    private bool skillcheck1;
    private bool skillcheck2;
    private bool skillcheck3;

    public GameObject healskill;
    public GameObject skilld;
    public GameObject skilld1;
    public GameObject skilld2;
    public GameObject skilld3;

    // Use this for initialization
    void Start()
    {
        skillcheck1 = false;
        skillcheck2 = false;
        skillcheck3 = false;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ActivateSkill1()
    {
        int points = GameObject.Find("Player").GetComponent<CharacterStats>().skillPoints;

        if (points >= 1 && skillcheck1 == false)
        {
            Text skilltext = GameObject.Find("Sakura Branch").GetComponent<Text>();
            skilltext.text = "Sakura Branch (Unlocked)";
            points = points - 1;
            GameObject.Find("Player").GetComponent<CharacterStats>().skillPoints -= 1;
            if (skillcheck1 == false)
            {
                //Activate a script that increases the maxhealth
                GameObject.Find("Player").GetComponent<CharacterStats>().maxHealth += 50;
            }
            skillcheck1 = true;
            var tempColor = skill1.GetComponent<Image>().color;
            tempColor.g = 1f;
            tempColor.r = 1f;
            tempColor.b = 1f;
            skill1.GetComponent<Image>().color = tempColor;

        }
        //print(points);

    }

    public void ActivateSkill2()
    {
        int points = GameObject.Find("Player").GetComponent<CharacterStats>().skillPoints;

        if (points >= 3 && skillcheck1 == true && skillcheck2 == false)
        {
            Text skilltext = GameObject.Find("Roots of the Sakura").GetComponent<Text>();
            skilltext.text = "Sakura Root (Unlocked)";
            points = points - 3;
            GameObject.Find("Player").GetComponent<CharacterStats>().skillPoints -= 3;
            if (skillcheck2 == false)
            {
                GameObject.Find("PunchTriggerZone").GetComponent<PunchTrigger>().energyrestore += 5;
                GameObject.Find("KickTriggerZone").GetComponent<KickTrigger>().energyrestore += 10;
            }
            skillcheck2 = true;
            var tempColor = skill2.GetComponent<Image>().color;
            tempColor.g = 1f;
            tempColor.r = 1f;
            tempColor.b = 1f;
            skill2.GetComponent<Image>().color = tempColor;
        }
        else
        {
            print("Requirements not met");
        }
        //print(points);

    }

    public void ActivateSkill3()
    {
        int points = GameObject.Find("Player").GetComponent<CharacterStats>().skillPoints;

        if (points >= 5 && skillcheck2 == true && skillcheck3 == false)
        {
            Text skilltext = GameObject.Find("Sakura Blossoms").GetComponent<Text>();
            skilltext.text = "Sakura Blossoms (Unlocked)";
            points = points - 5;
            GameObject.Find("Player").GetComponent<CharacterStats>().skillPoints -= 5;
            skilld.GetComponent<Text>().text = "Ability Skill\nEnergy Cost : 20\n\nHeals 20% max health.";
            healskill.GetComponent<Text>().text = "(Awakened) Heal";
            if (skillcheck3 == false)
            {
                // add skill here
                GameObject.Find("Player").GetComponent<PlayerController>().sakuracost -= 5;
                GameObject.Find("Player").GetComponent<PlayerController>().healamount -= 5;

            }
            skillcheck3 = true;
            var tempColor = skill3.GetComponent<Image>().color;
            tempColor.g = 1f;
            tempColor.r = 1f;
            tempColor.b = 1f;
            skill3.GetComponent<Image>().color = tempColor;


        }
        else
        {
            print("Requirements not met");
        }
        //print(points);

    }

    public void DisplaySkillText()
    {
        skilld.SetActive(true);
    }

    public void RemoveSkillText()
    {
        skilld.SetActive(false);
    }

    public void DisplaySkillText1()
    {
        skilld1.SetActive(true);
    }

    public void RemoveSkillText1()
    {
        skilld1.SetActive(false);
    }

    public void DisplaySkillText2()
    {
        skilld2.SetActive(true);
    }

    public void RemoveSkillText2()
    {
        skilld2.SetActive(false);
    }

    public void DisplaySkillText3()
    {
        skilld3.SetActive(true);
    }

    public void RemoveSkillText3()
    {
        skilld3.SetActive(false);
    }


}

