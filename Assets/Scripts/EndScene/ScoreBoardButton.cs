using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoardButton : MonoBehaviour
{
    // Ŭ�� �� ScoreBoard�� �˾�â���� ������ ScoreBoard ��ư�� ��ũ��Ʈ�Դϴ�.
    // �˾�â�� �����ִ� ���¿��� �ٽ� ������ �˾�â�� ������ ��������ϴ�.

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
