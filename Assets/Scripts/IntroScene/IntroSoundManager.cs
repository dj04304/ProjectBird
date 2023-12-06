using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class IntroSoundManager : MonoBehaviour
{
    public AudioSource bgm;
    public AudioSource hit;
    public AudioSource down;
    public AudioSource fire;

    void Start()
    {
        BGM();

        ManiHit();
        ManyDown();
        ManyFire();
    }

    public void BGM()
    {
        bgm.volume = 0.1f;
        bgm.Play();
    }

    public void Hit()
    {
        hit.volume = 0.5f;
        hit.Play();
    }

    public void ManiHit()
    {
        Invoke("Hit", 4.77f);
        Invoke("Hit", 4.79f);
        Invoke("Hit", 4.90f);
        Invoke("Hit", 4.95f);
        Invoke("Hit", 5.00f);
        Invoke("Hit", 5.05f);
        Invoke("Hit", 5.20f);
        Invoke("Hit", 5.22f);
    }

    public void Down()
    {
        down.volume = 0.5f;
        down.Play();
    }

    public void ManyDown()
    {
        Invoke("Down", 5.70f);
        Invoke("Down", 5.75f);
        Invoke("Down", 5.80f);
        Invoke("Down", 5.85f);
        Invoke("Down", 5.90f);
        Invoke("Down", 6.0f);
        Invoke("Down", 6.1f);
    }

    public void Fire()
    {
        fire.volume = 0.5f;
        fire.Play();
    }

    public void ManyFire()
    {
        for (int i = 0; i < 23; i++)
        {
            Invoke("Fire", 7.5f + (i * 0.1f));
        }
    }
}
