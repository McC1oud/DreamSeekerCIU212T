using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalMusicManager : MonoBehaviour {

    public AudioClip _one, _two, _three, _four, _five, _six, _seven, _eight, _nine, _ten, _eleven;
         
    private AudioClip[] list = new AudioClip[11];

    public AudioSource audioPlayer;

    void Start()
    {
        list[0] = _one;
        list[1] = _two;
        list[2] = _three;
        list[3] = _four;
        list[4] = _five;
        list[5] = _six;
        list[6] = _seven;
        list[7] = _eight;
        list[8] = _nine;
        list[9] = _ten;
        list[10] = _eleven;

        InitMainMusic();
    }


    void Update()
    {
        if (!audioPlayer.isPlaying)
        {
            IntroStart();
        }
    }

    public void InitMainMusic()
    {
        audioPlayer.clip = list[1];
        audioPlayer.Play();
    }

    public void IntroStart()
    {
        audioPlayer.clip = list[2];
        audioPlayer.Play();
    }

    public void IntroLoop()
    {
        audioPlayer.clip = list[3];
        audioPlayer.Play();
    }

    public void IntroEnd()
    {
        audioPlayer.clip = list[4];
        audioPlayer.Play();
    }

    public void NeutralEnd()
    {
        audioPlayer.clip = list[5];
        audioPlayer.Play();
    }

    public void NeutralLoop()
    {
        audioPlayer.clip = list[6];
        audioPlayer.Play();
    }

    public void WinningIntro()
    {
        audioPlayer.clip = list[7];
        audioPlayer.Play();
    }

    public void WiiningLoop()
    {
        audioPlayer.clip = list[8];
        audioPlayer.Play();
    }

    public void WinningEnd()
    {
        audioPlayer.clip = list[9];
        audioPlayer.Play();
    }

    public void WonTrack()
    {
        audioPlayer.clip = list[10];
        audioPlayer.Play();
    }

    public void InTroubleLoop()
    {
        audioPlayer.clip = list[11];
        audioPlayer.Play();
    }



}
