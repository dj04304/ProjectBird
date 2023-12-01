using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneManager : MonoBehaviour
{
    // EndScene���� ������ ��� �۵��ؾߵǴ� �۾����� �־����ϴ�.
    // �۵��ؾߵǴ� �۾���
    // 1. Ȱ��ȭ�� ScoreBoard�� �ݾ��ֱ�

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
