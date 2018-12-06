using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


// Not sure how to do inheritance properly
public class RangeEnemyController : EnemyController {

    public float attackSpeed = 0.5f;
    public float attackCooldown = 0f;
    public float attackDelay = 10f;

    public GameObject prefabToSpawn;

    Transform target;
    NavMeshAgent agent;
    

    // Use this for initialization
    void Start ()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        attackCooldown -= Time.deltaTime;
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance)
            {
                AttackSequence();
            }

            FaceTarget();
        }

        

    }


    public override void AttackSequence()
    {
        if (attackCooldown <= 0f)
        {
            print("Preparing Attack");
            Instantiate(prefabToSpawn, this.transform.position + new Vector3( 0 , 0.5f, -1 ), Quaternion.identity);
            attackCooldown = 1f / attackSpeed;
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
