using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class IntroSoundManager : MonoBehaviour
{
    public AudioSource bgm;
    public AudioSource hit;
    public float EffectVolume = 50;

    void Start()
    {
        bgm.volume = (float)0.07;
    }

    public void Hit()
    {
        hit.volume = EffectVolume;
        hit.Play();
    }

}
