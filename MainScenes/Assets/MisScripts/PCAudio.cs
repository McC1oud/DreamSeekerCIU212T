using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCAudio : MonoBehaviour {

    public AudioClip _a, _b, _c, _d, _e, _f, _g, _h, _i, _j, _k, _l, _m, _n, _o, _p, _q, _r, _s, _t, _u, _v, _w;
   
    private AudioClip[] list = new AudioClip[23];

    public AudioSource audioPlayer;

    void Start()
    {
        list[0] = _a;
        list[1] = _b;
        list[2] = _c;
        list[3] = _d;
        list[4] = _e;
        list[5] = _f;
        list[6] = _g;
        list[7] = _h;
        list[8] = _i;
        list[9] = _j;

        list[10] = _k;
        list[11] = _l;
        list[12] = _m;
        list[13] = _n;
        list[14] = _o;
        list[15] = _p;
        list[16] = _q;
        list[17] = _r;
        list[18] = _s;
        list[19] = _t;
        list[20] = _u;

        list[21] = _v;
        list[22] = _w;

    
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetButton("Fire3"))
        {
            ActivatePunch();
        }   

    }

    public void ActivatePunch()
    {
        
        audioPlayer.clip = list[Random.Range(0,22)];
        audioPlayer.Play();

    }
}
