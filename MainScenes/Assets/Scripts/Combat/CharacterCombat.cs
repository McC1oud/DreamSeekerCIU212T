using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{

    CharacterStats myStats;

    //Can be set in character stats
    public float attackSpeed = 1f;
    private float attackCooldown = 0f;

    public float attackDelay = 2f;

    // Need to recheck what this does
    public event System.Action OnAttack;


	// Use this for initialization
	void Start ()
    {
        myStats = GetComponent<CharacterStats>();
		
	}

    // Update is called once per frame
    void Update()
    {
        attackCooldown -= Time.deltaTime;

    }

    public void Attack(CharacterStats targetStats)
    {
        // targetStats.TakeDamage(20);

        if (attackCooldown <= 0f)
        {
            // Need to fix initial Attack Delay
            // Currently both Preparing attack and executing attack are playing at the same time, which means theres no delay for animation?
            print("Preparing Attack");
            StartCoroutine(DoDamage(targetStats, attackDelay));

            if (OnAttack != null)
            {
                OnAttack();
            }

            print("Executing Attack");
            attackCooldown = 1f / attackSpeed;
        }
        

    }

    // meant to be the delay for first attack?
    IEnumerator DoDamage (CharacterStats stats, float delay)
    {
        yield return new WaitForSeconds(delay);

        stats.TakeDamage(myStats.damage.GetValue(), CritChance());
    }

    bool CritChance()
    {
        // Chance of critting hard coded to 50%
        // create formula to increase critcal chance based on stats
        int criticalchance = Random.Range(0, 100);
        if (criticalchance < 50)
            return true;
        // else
        return false;
    }
}
