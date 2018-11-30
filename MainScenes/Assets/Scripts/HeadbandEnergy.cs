using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadbandEnergy : MonoBehaviour {

    Vector3 headband;
    CharacterStats myStats;
    public float curEnergy;
    public float maxEnergy;

    // Use this for initialization
    void Start()
        {
        myStats = GameObject.Find("Player").GetComponent<CharacterStats>();
        }

    // Update is called once per frame
    void Update()
        {
        headband = transform.localScale;

        curEnergy = myStats.currentEnergy;

        maxEnergy = myStats.maxEnergy;

        headband.x = ((curEnergy / maxEnergy) * 0.05f);

        transform.localScale = headband;

        if (Input.GetKeyDown(KeyCode.N))
            {
            Debug.Log(headband);
            headband.x += .5f;

            transform.localScale = headband;

            Debug.Log(headband);
            }

        if (Input.GetKeyDown(KeyCode.M))
            {
            Debug.Log(curEnergy);
            headband.x -= .5f;

            transform.localScale = headband;
            }

        }
    }
