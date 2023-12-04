using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlMonster : Monster
{

    public void SetOwlHealth(int newHealth)
    {
        health = newHealth;

        //Debug.Log("부엉이 값: " + newHealth);
    }

    public void SetOwlScore(int newScore)
    {
        score = newScore;

        //Debug.Log("부엉이 값: " + newScore);
    }

}
