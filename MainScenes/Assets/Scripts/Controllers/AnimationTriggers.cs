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
        if(Input.GetMouseButtonDown(0) || Input.GetButton("Fire3") && punchActive)
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

       if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
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
        if (Input.GetKeyDown(KeyCode.U) || Input.GetAxis("Horizontal3") > 0)
        {
            anim.Play("Sakura Ability Heal");
        }

        //Tiger Skill

        if (Input.GetKeyDown(KeyCode.I) || Input.GetAxis("Vertical3") < 0)
        {
            anim.Play("Tiger Ability Slam");
        }

        //Dragon Skill
        if (Input.GetKeyDown(KeyCode.O) || Input.GetAxis("Vertical3") > 0)
        {
            anim.Play("Push Strike");
        }

        //Dash Skill
        if (Input.GetKeyDown(KeyCode.LeftShift)  || Input.GetButton("LBumper"))
        {
            anim.Play("MC Running Jump");
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
}

