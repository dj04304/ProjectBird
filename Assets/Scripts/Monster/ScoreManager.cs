using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int _sumScore;

    private void Update()
    {
        GameManager.Instance.TotalScore = _sumScore;

        //Debug.Log("합산: " + _sumScore);
    }

    public void AddScore(int score)
    {
        _sumScore += score;

    }

}
