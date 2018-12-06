using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EBarScript : MonoBehaviour {

    // Use this for initialization
    CharacterStats myStats;
    public float curEnergy;
    public float maxEnergy;


    [SerializeField]
    private float fillAmount;

    [SerializeField]
    private Image content;
    void Start()
    {
        myStats = GameObject.Find("Player").GetComponent<CharacterStats>();
    }

    // Update is called once per frame
    void Update()
    {
        curEnergy = myStats.currentEnergy;
        maxEnergy = myStats.maxEnergy;
        HandleBar();


    }

    private void HandleBar()
    {
        content.fillAmount = curEnergy / maxEnergy;
    }

    //private float Map(float value, float inMin, float inMax,float outMin, float outMax)
    //{
    //    return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    //    // current health - minimum health * 1 - 0 / max health - minhealth + 0
    //    // 50 - 0 * 1 / 100
    //}


}
