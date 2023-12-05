using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneManager : MonoBehaviour
{
    public GameObject ScoreBoard;

    private void Awake()
    {
        ScoreBoard.SetActive(false);
    }

    public void ShowScoreBoard()
    {
        ScoreBoard.SetActive(true);
    }

    public void OnHomeBtnClick()
    {
        Debug.Log("Start Scene으로 이동합니다");

        //SceneManager.LoadScene("StartScene");
    }

    public void OnQuitBtnClick()
    {
        Application.Quit();
    }

    public void OnReplayBtnClick()
    {
        Debug.Log("Main Scene으로 이동합니다");

        //SceneManager.LoadScene("MainScene");
    }
}
