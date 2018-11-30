using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_AnimationController : MonoBehaviour {

    public Animator anim;
    public float lookRadius = 20f;
    Transform target;

    void Start()
    {
        target = PlayerManager.instance.player.transform;
        anim = GetComponent<Animator>();
    }

    public void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);



        if (distance <= lookRadius)
        {
            if (distance > 4)
            {
                anim.SetBool("playerChase", true);
                anim.Play("Run");
            }

        }

        if (distance <= 4)
        {
            anim.SetBool("playerChase", false);
        }

        if (distance > lookRadius)
        {
            anim.SetBool("playerChase", false);
        }

    }

    public void DoAnAttack()
    {
        int randoNum = Random.RandomRange(0, 2);
        int shouldISlap = Random.RandomRange(0, 4);

        if (shouldISlap == 0)
        {
          //  anim.SetBool("slapMyself", true);
        }

        switch (randoNum)
        {

            case 0:
                {
                    anim.Play("E Attack HiPalm");
                    break;
                }

            case 1:
                {
                    anim.Play("E Attack HeavyBite");
                    break;
                }
        }

       


    }
}
