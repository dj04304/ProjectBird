using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class IntroSoundManager : MonoBehaviour
{
    public AudioSource bgm;
    public AudioSource hit;

    public float EffectVolume = 30;

    void Start()
    {
        bgm.volume = (float)0.1;
    }

    public void BGM()
    {
        bgm.Play();
    }

    public void Hit()
    {
        hit.volume = EffectVolume;
        hit.Play();
    }

}
