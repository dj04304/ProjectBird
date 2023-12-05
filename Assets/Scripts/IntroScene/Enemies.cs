using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public GameObject EnemiesObject;

    public float delayTime = 2f;

    public void Awake()
    {
        EnemiesObject.SetActive(false);
    }

    public void Start()
    {
        Invoke("PlayEnemiesAnim", delayTime);
    }

    private void PlayEnemiesAnim()
    {
        EnemiesObject.SetActive(true);
    }
}
