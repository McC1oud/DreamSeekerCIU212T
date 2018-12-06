using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

    public Animator anim;
    public float lookRadius = 20f;

    Transform target;
    NavMeshAgent agent;
    CharacterCombat combat;
	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();


        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent<CharacterCombat>();
	}
	
	// Update is called once per frame
	public virtual void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {

            agent.SetDestination(target.position);
           
            if (distance <= agent.stoppingDistance)
            {       
                AttackSequence();
            }
        }



    }

    public virtual void AttackSequence()
    {
        CharacterStats targetStats = target.GetComponent<CharacterStats>();
        if (targetStats != null)
        {
            // attack  player target
            combat.Attack(targetStats);
        }

        // face target
        FaceTarget();
    }

    void FaceTarget ()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

}
