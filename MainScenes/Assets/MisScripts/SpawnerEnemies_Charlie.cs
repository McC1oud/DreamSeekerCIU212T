using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemies_Charlie : MonoBehaviour
{

    public GameObject a_Baddy;

    public float a_spawnSpeed;
    public float a_Count;

    void Start()
    {
        StartCoroutine("SpawnSomeBoys");
    }

    IEnumerator SpawnSomeBoys()
    {
        for (int i = 0; i < a_Count; i++)
        {
            Instantiate(a_Baddy, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(a_spawnSpeed);
        }

        this.transform.parent.parent.GetComponent<EndCombat>().endCombatC = true;

    }
}
