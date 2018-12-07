using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingSounds : MonoBehaviour {

    public AudioClip _a, _b, _c, _d, _e, _f, _g, _h, _i, _j, _k, _l, _m, _n, _o, _p, _q, _r, _s, _t, _u, _v, _w;

    bool aDir, sDir, dDir, wDir, axisDir;

    bool currentlyWalking = false;

    private AudioClip[] list = new AudioClip[14];

    public Animator anim;

    public AudioSource audioPlayer;

    void Start()
    {
        anim = transform.parent.GetComponent<Animator>();

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

    }

    void Update()
    {
        if(anim.GetBool("Run") && !currentlyWalking)
        {
            currentlyWalking = true;
            StartCoroutine("WalkPlz");
            PlayAWalk();
        }
    }

    public void PlayAWalk()
    {
        audioPlayer.clip = list[Random.Range(0, 14)];
        audioPlayer.Play();
    }

    IEnumerator WalkPlz()
    {
        yield return new WaitForSeconds(0.35f);
        currentlyWalking = false;
    }

}
