using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(CharacterStats))]
[RequireComponent(typeof(NavMeshAgent))]
public class PlayerController : MonoBehaviour
{
    public GameObject ballSpawn;
    public GameObject logicDummy;
    public GameObject punchingBag;
    public GameObject characterMod;


    private int targetsAvailable;
    private int currentLockTarget = 0;
    private int maxTarget;

    private bool targetOn = false;
    private bool currentlyLockedOn = false;
    private bool letsLockOn = false;

    public Camera mainCam;

    public GameObject playerModel;
    private Vector3 directionHeading;
    private bool mF, mB, mL, mR;

    CharacterStats myStats;
    NavMeshAgent agent;
    public float charSpeed;
    public float originalCharSpeed;
    public float rotationSpeed = 100f;
    private float diagNormSpeed = 0.711f;

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
    public BoxCollider poundCollider;
    //mesh
    public MeshRenderer punchmesh;
    public MeshRenderer kickmesh;
    public MeshRenderer poundmesh;

    public List<GameObject> nearbyEnemyList;

    // energy cost of skills
    public int tigercost = 40;
    public int dragoncost = 20;
    public int sakuracost = 30;

    //heal amount modifier
    public int healamount = 10;

   

    // Use this for initialization
    void Start()
    {
        nearbyEnemyList = new List<GameObject>();
        nearbyEnemyList.Add(logicDummy);

        directionHeading = new Vector3(0, 0, 0);
        mF = mB = mL = mR = false;
        originalCharSpeed = charSpeed;
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
        if (GameObject.Find("Menu").GetComponent<Controller>().GameIsPaused == true)
        {
            return;
        }
        
        targetsAvailable = nearbyEnemyList.Count;

        if (targetsAvailable <= 0)
        {
            nearbyEnemyList.Add(logicDummy);
        }

        if (nearbyEnemyList.Count > 1)
        {
            nearbyEnemyList.Remove(logicDummy);
        }


        if(currentLockTarget > targetsAvailable-1)
        {
            currentLockTarget = targetsAvailable-1;
        }

        if (targetsAvailable == 1)
        {
            currentLockTarget = 0;
        }

        if (Input.GetButtonDown("Fire2"))
        {
            currentLockTarget++;

            if (currentLockTarget > targetsAvailable-1)
            {
                currentLockTarget = targetsAvailable-1;
            }
        }
        if (Input.GetButtonDown("Fire4"))
        {
            currentLockTarget--;

            if(currentLockTarget < 0)
            {
                currentLockTarget = 0;
            }

            if (targetsAvailable == 1)
            {
                currentLockTarget = 0;
            }
        }



        LockOnChecker();

        attackcd -= Time.deltaTime * attackspd;
        dashcd -= Time.deltaTime;
        energyCd -= Time.deltaTime;

        float x = Input.GetAxisRaw("Horizontal");
        float z  = Input.GetAxisRaw("Vertical");

        Vector3 directionMovement = new Vector3(x, 0, z);

        float newCharSpeed = charSpeed;

        if (x != 0 && z != 0)
        {
            newCharSpeed = charSpeed * diagNormSpeed;
            
        }

        if (x == 0 & z == 0)
        {
            mL = false;
            mR = false;
        }

        if (x < 0)
        {
            mL = true;
            mR = false;
            transform.Translate(-mainCam.transform.right * (newCharSpeed));
           
            directionHeading = -mainCam.transform.right;

        }

        if (x > 0)
        {
            mL = false;
            mR = true;
            transform.Translate(mainCam.transform.right * (newCharSpeed));
        
            directionHeading = mainCam.transform.right;

        }

        if (z < 0)
        {
            mB = true;
            mF = false;
            transform.Translate(-mainCam.transform.forward * (newCharSpeed));
        
            directionHeading = -mainCam.transform.forward;

        }

        if (z > 0)
        {
            mB = false;
            mF = true;
            transform.Translate(mainCam.transform.forward * (newCharSpeed));
     
            directionHeading = mainCam.transform.forward;

        }

        if (mF == true && mR == true)
        {
            mB = false;
            mL = false;

            directionHeading = mainCam.transform.forward + mainCam.transform.right;
        }

        if (mR == true && mB == true)
        {

            mL = false;
            mF = false;
            directionHeading = -mainCam.transform.forward + mainCam.transform.right;
        }

        if (mB == true && mL == true)
        {
            mF = false;
            mR = false;
            directionHeading = -mainCam.transform.forward + -mainCam.transform.right;
        }

        if (mL == true && mF == true)
        {
            mR = false;
            mB = false;
            directionHeading = mainCam.transform.forward + -mainCam.transform.right;
        }

        directionHeading.y = 0;
        if(directionHeading != Vector3.zero)
        {
            if(!currentlyLockedOn)
            {
                playerModel.transform.rotation = Quaternion.LookRotation(directionHeading);
            }
           
        }
        
        mF = mB = mL = mR = false;

        
         // Dash  -- Add CooldDown to Dash
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetButton("LBumper"))
        {
            if (dashcd <= 0)
            {
                charSpeed *= 10;
                print("Dash");
                dashcd = 1f;
            }
        
            // Bandaid Solution. Find a better way to code dash
           
        }
        
    
        // Checking for current Speed. 
        if (charSpeed > originalCharSpeed)
        {
            charSpeed -= .1f;
        }
        if (charSpeed < originalCharSpeed)
        {
            charSpeed = originalCharSpeed;
        }
        
        //Punch
        // Spawn collider in front when animation shows punch has extended and then destroy collider. Before destroy check if it hit and deal damage if hit enemy
        if (Input.GetMouseButtonDown(0) || Input.GetButton("Fire3"))//Button mapped to Gamepad X
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

        if (Input.GetMouseButtonDown(1) || Input.GetButton("Fire1"))//Button mapped to Gamepad A
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


        //Start Skills

        //Healing Skill
        if (Input.GetKeyDown(KeyCode.U) || Input.GetAxis("Horizontal3") > 0)
        {
            //Check if have enough energy
            if (myStats.currentEnergy < sakuracost)
            {
                Debug.Log("Not Enough Energy.");
            }
            else if (myStats.currentEnergy >= sakuracost)
            {
                if (energyCd <= 0)
                {
                    myStats.currentHealth +=  Mathf.RoundToInt(myStats.maxHealth / healamount);
                    myStats.currentEnergy -= sakuracost;
                    //Debug.Log("Heal " + (myStats.maxHealth / 5));
                    // Play heal animation
                }
                else
                {
                    //Debug.Log("On Cooldown.");
                }
                
                // Play heal animation

            }

        }

        //Tiger Skill
        // 
        if (Input.GetKeyDown(KeyCode.I) || Input.GetAxis("Vertical3") < 0)
        {
            //Check if have enough energy
            if (myStats.currentEnergy < tigercost)
            {
                Debug.Log("Not Enough Energy.");
            }

            else if (myStats.currentEnergy >= tigercost)
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
        if (Input.GetKeyDown(KeyCode.O) || Input.GetAxis("Vertical3") > 0)
        {
            // checks if you have 20 energy
            if (myStats.currentEnergy < dragoncost)
            {
                Debug.Log("Not Enough Energy.");
            }
            else if (myStats.currentEnergy >= dragoncost)
            {
                // Checks if attack is on cd/ animation is done from attack
                if (energyCd <= 0)
                {

                    Debug.Log("EnergyShot!");
                    Instantiate(energyBall, ballSpawn.transform.position + new Vector3(0, 1, 1), Quaternion.identity);
                    myStats.currentEnergy -= dragoncost;
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

        if (Input.GetKeyDown(KeyCode.P))
        {
            myStats.currentEnergy = 100;
        }

        //End Skills


    }

    //Start Lock on utilities
    private void LockOnChecker()
    {
        if (Input.GetButtonDown("RBumper") && !currentlyLockedOn)
        {
            letsLockOn = true;

        }

        if (Input.GetButtonDown("RBumper") && currentlyLockedOn)
        {
            letsLockOn = false;
            currentlyLockedOn = false;
        }

        if (letsLockOn)
        {
            LockOnEnemy();
            
        }

    }

    private void LockOnEnemy()
    {
        if(nearbyEnemyList[currentLockTarget] == null)
        {
            return;
        }
        Vector3 targetSet = new Vector3(nearbyEnemyList[currentLockTarget].transform.position.x, 0, nearbyEnemyList[currentLockTarget].transform.position.z);
        characterMod.transform.LookAt(targetSet);
        currentlyLockedOn = true;
        
    }

    public void DeletefromList(GameObject baddy)
    {
        nearbyEnemyList.Remove(baddy);
        
    }

    //End Lock on utilities

    //Start Coroutines for attacks

    IEnumerator Punching()
    {
        attackcd = 1f;
        punchCollider.enabled = true;
        punchmesh.enabled = true;
        yield return new WaitForSeconds(0.1f);
        punchCollider.enabled = false;
        punchmesh.enabled = false;
    }

    IEnumerator Kicking()
    {
        attackcd = 1.5f;
        kickCollider.enabled = true;
        kickmesh.enabled = true;
        yield return new WaitForSeconds(0.1f);
        kickCollider.enabled = false;
        kickmesh.enabled = false;
    }

    IEnumerator TigerPound()
    {
        Debug.Log("Pound");
        Time.timeScale = 0.3f;
        myStats.currentEnergy -= tigercost;
        energyCd = 1.5f;
        yield return new WaitForSeconds(0.3f);
        Time.timeScale = 1;
        poundCollider.enabled = true;
        poundmesh.enabled = true;
        yield return new WaitForSeconds(0.3f);
        poundCollider.enabled = false;
        poundmesh.enabled = false;
    }

    //End Coroutines for attacks
}