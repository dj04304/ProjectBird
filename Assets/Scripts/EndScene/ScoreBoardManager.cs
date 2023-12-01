using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoardManager : MonoBehaviour
{
    private int OneScore = 5;
    private int TwoScore = 4;
    private int ThrScore = 3;
    private int FouScore = 2;

    private GameObject OneS = GameObject.Find("BestScoreText");
    private GameObject TwoS = GameObject.Find("2ndScoreText");
    private GameObject ThrS = GameObject.Find("3ndScoreText");
    private GameObject FouS = GameObject.Find("4ndScoreText");

    private List<int> highScores = new List<int>();

    private void Start()
    {
        LoadScores();
    }


    void LoadScores()
    {
        highScores.Clear();
        for (int i = 1; i <= 3; i++)
        {
            int score = PlayerPrefs.GetInt("HighScore" + i, 0);
            highScores.Add(score);
        }
    }

    void DisplayScores()
    {
    //    OneS.Text = highScores[0];
    //    TwoS.Text = highScores[1];
    //    ThrS.Text = highScores[2];
    //    FouS.Text = highScores[3];
    // 위에 Text를 TMP로 해서 가져와서 입력되도록
    }
}
