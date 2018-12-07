using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSkill : MonoBehaviour {

    public CharacterStats myStats;
    public PlayerController energyCheck;
    public int dragoncheck;
    public int sakuracheck;
    public int tigercheck;
    public int currentEnergy;
    public GameObject dragon;
    public GameObject sakura;
    public GameObject tiger;


    // Use this for initialization
    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        dragoncheck = energyCheck.dragoncost;
        sakuracheck = energyCheck.sakuracost;
        tigercheck = energyCheck.tigercost;
        currentEnergy = myStats.currentEnergy;

        if (dragoncheck <= currentEnergy)
        {
            dragon.SetActive(true);
        }
        else
        {
            dragon.SetActive(false);
        }

        if (sakuracheck <= currentEnergy)
        {
            sakura.SetActive(true);
        }
        else
        {
            sakura.SetActive(false);
        }
        if (tigercheck <= currentEnergy)
        {
            tiger.SetActive(true);
        }
        else
        {
            tiger.SetActive(false);
        }
    }
}
