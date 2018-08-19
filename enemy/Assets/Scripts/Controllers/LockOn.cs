using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOn : MonoBehaviour
{

    public GameObject punchingBag;
    private bool targetOn = false;


    void Update()
    {
        if(Input.GetButton("RBumper"))
        {
            transform.LookAt(punchingBag.transform.position);
            print("Looking at em");
        }
       



    }

}