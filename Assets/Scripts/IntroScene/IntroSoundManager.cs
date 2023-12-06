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

    }

    public void BGM()
    {
        bgm.volume = 10f;
        bgm.Play();

    }

    public void Hit()
    {
        hit.volume = EffectVolume;
        hit.Play();
    }

}
