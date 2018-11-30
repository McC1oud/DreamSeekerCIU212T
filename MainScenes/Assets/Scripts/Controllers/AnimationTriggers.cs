using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTriggers : MonoBehaviour {

    public float attackSpeed;
    private bool punchActive = true;

    public float combatTimer;
    private const float timerConstant = 5;
    private bool miniCombatTimer = true;
    public Animator anim;
    bool aDir, sDir, dDir, wDir, axisDir;
    bool isPunching = false;
    bool inCombat = false;

    bool sakuraCD = true, tigerCD = true, dragonCD = true, dashCD = true;

	void Start ()
    {
        anim = GetComponent<Animator>();
        
    }
	
	void Update ()
    {
        ButtonCheck();
    }

    public void ButtonCheck()
    {
        DownButtons();

        UpButtons();

        CheckForAttacking();

        CompareButtons();

    }

    public void CheckForAttacking()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetButtonDown("Fire3") && punchActive)
        {
            ActivateAttacks();
            inCombat = true;
            anim.SetBool("inCombat", inCombat);

            if(miniCombatTimer)
            {
                miniCombatTimer = false;
                StartCoroutine("CombatStanceCounter");
            }
            

            isPunching = true;
        }

        SpecialsDetection();
    }

    public void DownButtons()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

       

        if (x != 0 || z != 0)
        {
            axisDir = true;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            wDir = true;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            aDir = true;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            sDir = true;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            dDir = true;
        }

    }

    public void UpButtons()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        if (x == 0 && z == 0)
        {
            axisDir = false;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            wDir = false;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            aDir = false;
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            sDir = false;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            dDir = false;
        }

    }

    public void CompareButtons()
    {
        if(aDir || sDir || dDir || wDir || axisDir)
        {
            anim.SetBool("Run", true);
        }

        else
        {
            anim.SetBool("Run", false);
        }
    }

    public void ActivateAttacks()
    {
        int randoNum = Random.RandomRange(0, 5);

        switch (randoNum)
        {

            case 0:
                {
                    anim.Play("LeftPunch");
                    break;
                }

            case 1:
                {
                    anim.Play("Left Slip Punch");
                    break;
                }

            case 2:
                {
                    anim.Play("Right Elbow Strike");
                    break;
                }

            case 3:
                {
                    anim.Play("Left Elbow Strike");
                    break;
                }

            case 4:
                {
                    anim.Play("Right Strike Punch");
                    break;
                }

            case 5:
                {
                    anim.Play("Right Slip punch");
                    break;
                }

        }
    }

    public void SpecialsDetection()
    {
        //Sakura Skil
        if (Input.GetKeyDown(KeyCode.U) || Input.GetAxis("Horizontal3") > 0 && sakuraCD)
        {
            anim.Play("Sakura Ability Heal");
            StartCoroutine("CDSakura");
        }

        //Tiger Skill

        if (Input.GetKeyDown(KeyCode.I) || Input.GetAxis("Vertical3") < 0 && tigerCD)
        {
            anim.Play("Tiger Ability Slam");
            StartCoroutine("CDTiger");
        }

        //Dragon Skill
        if (Input.GetKeyDown(KeyCode.O) || Input.GetAxis("Vertical3") > 0 && dragonCD)
        {
            anim.Play("Push Strike");
            StartCoroutine("CDDragon");
        }

        //Dash Skill
        if (Input.GetKeyDown(KeyCode.LeftShift)  || Input.GetKeyDown(KeyCode.Joystick1Button4) && dashCD)
        {
          
            anim.Play("MC Running Jump");
            StartCoroutine("CDDash");
        }
    }

    IEnumerator CombatStanceCounter()
    {
        yield return new WaitForSeconds(combatTimer);
        inCombat = false;
        miniCombatTimer = true;
        anim.SetBool("inCombat", inCombat);
        combatTimer = timerConstant;
    }

    IEnumerator PunchTimer()
    {
        punchActive = false;
        yield return new WaitForSeconds(attackSpeed);
        punchActive = true;
    }

    IEnumerator CDSakura()
    {
        sakuraCD = false;
        yield return new WaitForSeconds(2f);
        sakuraCD = true;
    }

    IEnumerator CDTiger()
    {
        tigerCD = false;
        yield return new WaitForSeconds(2f);
        tigerCD = true;
    }

    IEnumerator CDDragon()
    {
        dragonCD = false;
        yield return new WaitForSeconds(2f);
        dragonCD = true;
    }

    IEnumerator CDDash()
    {
        dashCD = false;
        yield return new WaitForSeconds(2f);
        dashCD = true;
    }

}


