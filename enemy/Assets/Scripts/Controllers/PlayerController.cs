using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(CharacterStats))]
[RequireComponent(typeof(NavMeshAgent))]
public class PlayerController : MonoBehaviour
{
    CharacterStats myStats;
    NavMeshAgent agent;
    public float speed;
    public float rotationSpeed = 100f;

    //attack cooldown
    public float attackcd;
    public float attackspd;

    //dash cooldown
    public float dashcd;

    //Setting up for dragon skill energy shot
    public Transform ProjectileSpawn { get; set; }
    Projectile projectile;
    public GameObject energyBall;
    public float energyCd;

    //Colliders
    public BoxCollider punchCollider;
    //public GameObject punch;    was for spawning collider
    public BoxCollider kickCollider;
    public CapsuleCollider poundCollider;
    //mesh
    public MeshRenderer punchmesh;
    public MeshRenderer kickmesh;
    public MeshRenderer poundmesh;

    // Use this for initialization
    void Start()
    {
        attackspd = 1;
        attackcd = 0;
        dashcd = 0;
        energyCd = 0;
        agent = GetComponent<NavMeshAgent>();
        myStats = GetComponent<CharacterStats>();
    }

    // Update is called once per frame
    void Update()
    {
        attackcd -= Time.deltaTime * attackspd;
        dashcd -= Time.deltaTime;
        energyCd -= Time.deltaTime;
        // var speed = 5.0;
        if (Input.GetKey(KeyCode.A))
            Debug.Log("Pressing A");

        if (Input.GetKey(KeyCode.W))
            Debug.Log("Pressing W");

        if (Input.GetKey(KeyCode.S))
            Debug.Log("Pressing S");

        if (Input.GetKey(KeyCode.D))
            Debug.Log("Pressing D");


        //var x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        //var z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        float x = Input.GetAxisRaw("Horizontal");
        float z  = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(x, 0, z);

        //transform.Translate(x, 0, z);
        if (movement != Vector3.zero)
        {
            // change the float to make the rotation more or less snappy
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement.normalized), 1f);
        }

        transform.Translate(movement * speed * Time.deltaTime, Space.World);

        // Dash  -- Add CooldDown to Dash
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (dashcd <= 0)
            {
                speed = 40;
                print("Dash");
                dashcd = .5f;
            }
        
            // Bandaid Solution. Find a better way to code dash
           
        }
        // Checking for current Speed. 
        if (speed > 10)
        {
            speed -= 100* Time.deltaTime;
        }
        if (speed < 10)
        {
            speed = 10;
        }
        
        //Punch
        // Spawn collider in front when animation shows punch has extended and then destroy collider. Before destroy check if it hit and deal damage if hit enemy
        if (Input.GetMouseButtonDown(0))
        {
            if (attackcd <= 0)
            {
                Debug.Log("Punch");
                // Play attack animation
                // Check if attack hit enemy
                // If Enemy is hit recover 5 energy

                StartCoroutine(Punching());
                //Instantiate(punch, transform.position + new Vector3(0, 1, 1), Quaternion.identity);

                // myStats.currentEnergy += 5;
                // Debug.Log(transform.name + " gained 5 energy.");
            }
            else
            {
                Debug.Log("Attack On Cooldown.");
            }
            




           
        }

        //Kick

        if (Input.GetMouseButtonDown(1))
        {
            if (attackcd <= 0)
            {
                Debug.Log("Kick");
                // Play attack animation
                // Check if attack hit enemy
                // If Enemy is hit, recover 10 energy // Knock back enemies short distance
                StartCoroutine(Kicking());

                //myStats.currentEnergy += 10;
                //Debug.Log(transform.name + " gained 10 energy.");

            }
            else
            {
                Debug.Log("Attack On Cooldown.");
            }

      
        }


        //Skills
        //Healing Skill
        if (Input.GetKeyDown(KeyCode.U))
        {
            //Check if have enough energy
            if (myStats.currentEnergy < 25)
            {
                Debug.Log("Not Enough Energy.");
            }
            else if (myStats.currentEnergy >= 25)
            {
                if (energyCd <= 0)
                {
                    myStats.currentHealth += (myStats.maxHealth / 5);
                    myStats.currentEnergy -= 25;
                    Debug.Log("Heal " + (myStats.maxHealth / 5));
                    // Play heal animation
                }
                else
                {
                    Debug.Log("On Cooldown.");
                }
                myStats.currentHealth += (myStats.maxHealth / 5);
                myStats.currentEnergy -= 25;
                Debug.Log("Heal");
                // Play heal animation

            }

        }

        //Tiger Skill
        // 
        if (Input.GetKeyDown(KeyCode.I))
        {
            //Check if have enough energy
            if (myStats.currentEnergy < 30)
            {
                Debug.Log("Not Enough Energy.");
            }

            else if (myStats.currentEnergy >= 30)
            {
                // Checks if attack is on cd/ animation is done from attack
                if (energyCd <= 0)
                {
                    
                    StartCoroutine(TigerPound());
                    
                }
                else
                {
                    Debug.Log("On Cooldown.");
                }


            }
            
            // Play attack animation
            // Check if attack hit enemy
            // If hit knock back enemies certain distance
        }

        //Dragon Skill
        if (Input.GetKeyDown(KeyCode.O))
        {
            // checks if you have 20 energy
            if (myStats.currentEnergy < 20)
            {
                Debug.Log("Not Enough Energy.");
            }
            else if (myStats.currentEnergy >= 20)
            {
                // Checks if attack is on cd/ animation is done from attack
                if (energyCd <= 0)
                {

                    Debug.Log("EnergyShot!");
                    Instantiate(energyBall, transform.position + new Vector3(0, 1, 1), Quaternion.identity);
                    myStats.currentEnergy -= 20;
                    energyCd = 1.5f;
                }
                else
                {
                    Debug.Log("On Cooldown.");
                }
              
                
            }
               
            //Check if have enough energy
            // Play attack animation
            // Check if attack hit enemy
        }



    }

    IEnumerator Punching()
    {
        attackcd = 1f;
        punchCollider.enabled = true;
        punchmesh.enabled = true;
        yield return new WaitForSeconds(0.5f);
        punchCollider.enabled = false;
        punchmesh.enabled = false;
    }

    IEnumerator Kicking()
    {
        attackcd = 1.5f;
        kickCollider.enabled = true;
        kickmesh.enabled = true;
        yield return new WaitForSeconds(0.5f);
        kickCollider.enabled = false;
        kickmesh.enabled = false;
    }

    IEnumerator TigerPound()
    {
        Debug.Log("Pound");
        myStats.currentEnergy -= 30;
        energyCd = 1.5f;
        poundCollider.enabled = true;
        poundmesh.enabled = true;
        yield return new WaitForSeconds(0.5f);
        poundCollider.enabled = false;
        poundmesh.enabled = false;
    }


}