using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoardButton : MonoBehaviour
{
    // 클릭 시 ScoreBoard가 팝업창으로 열리는 ScoreBoard 버튼의 스크립트입니다.
    // 팝업창이 열려있는 상태에서 다시 누르면 팝업창이 닫히게 만들었습니다.

    private GameObject ScoreBrd;
    private bool ScoreBrdVisible;

    private void Awake()
    {
        ScoreBrd = GameObject.Find("ScoreBoard");
        ScoreBrdVisible = ScoreBrd.activeSelf;
    }

    public void OnScoreBoardBtnClick()
    {
        ScoreBrd.SetActive(ScoreBrdVisible);
        ScoreBrdVisible = !ScoreBrdVisible;
    }
}
