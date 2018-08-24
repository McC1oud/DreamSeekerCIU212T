using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

// Boss currently taking multiple instances of damage. Currently 2x usually but sometimes more
public class Boss1Control : MonoBehaviour {

    public float lookRadius = 20f;
    public GameObject prefabToSpawn;
    public Transform chargelocation;
    Transform target;
    NavMeshAgent agent;
    CharacterCombat combat;
    EnemyStats myStats;
    // Use this for initialization

    //Charge attack var
    public float chargeTimer;
    public float chargecd;
    public CapsuleCollider chargecollider;

    //Firing
    public int ballSpawn = 5;
    public int spawnstart = -4;
    public float ballcd;

    //NextAttack
    public float nextAttack;
    public int skillqueue;

    //enable win state
    public GameObject winState;

    void Start()
    {
        myStats = GetComponent<EnemyStats>();
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent<CharacterCombat>();
        chargeTimer = 0f;
        chargecd = 0f;
        ballcd = 0f;
        nextAttack = 0f;
        skillqueue = 1;
    }
    

    // Update is called once per frame
    public virtual void Update()
    {

        chargeTimer -= Time.deltaTime;
        ballcd -= Time.deltaTime;
        nextAttack -= Time.deltaTime;

        //Set this to phase 3 and add collider for charging attack
        if (nextAttack <= 0)
        {
            if (skillqueue == 1)
            {
                StartCoroutine(PhaseTwo());
                nextAttack = 4f;
                
            }
            else if (skillqueue == 2)
            {
                StartCoroutine(PhaseThree());
                nextAttack = 2f;
                
            }
        }

        if (chargeTimer <= 0)
        {
            StartCoroutine(Charging());
			StartCoroutine (StopCharge ());
            chargeTimer = 5;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {

            StartCoroutine(Charging());
			StartCoroutine (StopCharge ());

        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            //for (int i = 0; i < ballSpawn; i++)
            //{
                
            //    StartCoroutine(Firing());
            //}
            //spawnstart = -4;

            while (ballSpawn > 0)
            {
                StartCoroutine(Firing());
                new WaitForSeconds(1);
                ballSpawn -= 1;
            }
            ballSpawn = 5;
            spawnstart = -4;


        }




        if (myStats.currentHealth > (2 * myStats.maxHealth / 3))
        {
            StartCoroutine(PhaseOne());
            //StartCoroutine(Looking());
            
        }

        else if (myStats.currentHealth > myStats.maxHealth / 3)
        {
            StartCoroutine(PhaseTwo());
            if (chargeTimer <= 0)
            {
                Debug.Log("charging");
                StartCoroutine(Charging());
				StartCoroutine (StopCharge ());
                chargeTimer = 3f;
            }

        }
        else if (myStats.currentHealth > 0)
        {
            StartCoroutine(PhaseThree());
            if (ballcd <= 0)
            {
                while (ballSpawn > 0)
                {
                    StartCoroutine(Firing());
                    new WaitForSeconds(1);
                    ballSpawn -= 1;
                }
                ballSpawn = 5;
                spawnstart = -4;
                ballcd = 3f;
            }
        }

        if (myStats.currentHealth <= 0)
            {
            //WinsTate here
            print("you win");
            //Add WIN Ui herer and whicch gives options to restart. set the load scene to the UI
            winState.SetActive(true);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //restart level
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //StartCoroutine(Win());


            }



    }

    IEnumerator Win()
        {
        yield return new WaitForSeconds(1);
        print("you win");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    IEnumerator Charging()

    {
        //chargeTimer = 2f;
        //chargeTimer -= Time.deltaTime;
        FaceTarget();
        agent.SetDestination(target.position);
        agent.speed = 0;
        yield return new WaitForSeconds(1f);
        //transform.position = target.position*Time.deltaTime;
        chargecollider.enabled = true;
        agent.speed = 20;
        yield return new WaitForSeconds(0.3f);
        
        agent.SetDestination(target.position);
        new WaitForSeconds(2f);
        
        


    }

	IEnumerator StopCharge()
	{
		yield return new WaitForSeconds (2f);
		chargecollider.enabled = false;
	}

    IEnumerator Firing()

    {
        //chargeTimer = 2f;
        //chargeTimer -= Time.deltaTime;
        FaceTarget();

        //transform.position = target.position*Time.deltaTime;
        yield return new WaitForSeconds(1f);
        Instantiate(prefabToSpawn, this.transform.position + new Vector3(spawnstart, 3, 0), Quaternion.identity);
        spawnstart += 2;


    }

    IEnumerator NextSkill()
    {
        skillqueue = Random.Range(1, 2);
        yield return new WaitForSeconds(1f);
    }

    IEnumerator Looking()

    {
        yield return new WaitForSeconds(0f);

        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {

            agent.SetDestination(target.position);


            if (distance <= agent.stoppingDistance)
            {
                Debug.Log("attack");

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

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 20f);

        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    IEnumerator PhaseOne()
    {
        //Debug.Log("One");
       
        yield return new WaitForSeconds(0f);
        
    }

    IEnumerator PhaseTwo()
    {
        //Debug.Log("Two");
        if (chargeTimer <= 0)
        {
            Debug.Log("charging");
            StartCoroutine(Charging());
            chargeTimer = 3f;
            skillqueue = Random.Range(1, 3);
        }
        yield return new WaitForSeconds(0f);

    }

    IEnumerator PhaseThree()
    {
        //Debug.Log("Three");
        if (ballcd <= 0)
        {
            while (ballSpawn > 0)
            {
                StartCoroutine(Firing());
                new WaitForSeconds(1);
                ballSpawn -= 1;
            }
            ballSpawn = 5;
            spawnstart = -4;
            ballcd = 3f;
            skillqueue = Random.Range(1, 3);
        }
        yield return new WaitForSeconds(0f);

    }


}

