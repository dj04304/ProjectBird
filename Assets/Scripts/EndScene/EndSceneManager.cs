using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneManager : MonoBehaviour
{
    // EndScene으로 들어오는 경우 작동해야되는 작업들을 넣었습니다.
    // 작동해야되는 작업들
    // 1. 활성화된 ScoreBoard를 닫아주기

    private GameObject ScoreBrd;
    private bool ScoreBrdVisible;


    void Start()
    {
        ScoreBrdClose();
    }

    private void ScoreBrdClose()
    {
        ScoreBrd = GameObject.Find("ScoreBoard");

        if (ScoreBrd != null)
        {
            ScoreBrdVisible = ScoreBrd.activeSelf;
        }

        ScoreBrdVisible = !ScoreBrdVisible;
        ScoreBrd.SetActive(ScoreBrdVisible);
    }
}
