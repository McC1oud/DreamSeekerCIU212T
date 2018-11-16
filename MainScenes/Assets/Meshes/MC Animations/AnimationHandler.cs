using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour {

    Animator anim;

    private bool frameReset = false;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        //if (Input.GetMouseButtonDown(0) || Input.GetButton("Fire3"))
        if (Input.GetMouseButtonDown(0))
        {
            //anim.SetBool("punchIt", true);
            

            int randoNum = Random.RandomRange(0,5);

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

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) )
        {
           // anim.Play("MC Sprinting");
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            anim.Play("MC Sprinting");
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) )

        {
            anim.Play("Idle");
            
        } 

    }


}
