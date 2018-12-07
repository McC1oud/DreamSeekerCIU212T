using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableBossBarrier : MonoBehaviour
{

    public int barrierCount = 0;

    void Start()
    {
     
    }


    void Update()
    {

        if (barrierCount == 4)
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            Destroy(this);
        }
    }
}
