using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour {


    public AudioClip _A, _B, _C, _D, _E, _F, _G, _H, _I, _J, _K, _L, _M, _N, _O, _P, _Q, _R, _S, _T;
    public int currentLoop = 0;

    private AudioClip[] list = new AudioClip[20];

    public AudioSource audioPlayer;

    private bool initiatorBool = true;

    void Start()
    {
        list[0] = _A;
        list[1] = _B;
        list[2] = _C;
        list[3] = _D;
        list[4] = _E;
        list[5] = _F;
        list[6] = _G;
        list[7] = _H;
        list[8] = _I;
        list[9] = _J;

        list[10] = _K;
        list[12] = _L;
        list[11] = _M;
        list[13] = _N;
        list[14] = _O;
        list[15] = _P;
        list[16] = _Q;
        list[17] = _R;
        list[18] = _S;
        list[19] = _T;






    }

    public void ActivateDamageTaken()
    {

        audioPlayer.clip = list[Random.Range(0, 20)];
        audioPlayer.Play();

    }
}
