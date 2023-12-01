using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoardManager : MonoBehaviour
{
    public TextMeshProUGUI BestScoreText;
    public TextMeshProUGUI SecondScoreText;
    public TextMeshProUGUI ThirdScoreText;
    public TextMeshProUGUI FourthScore;

    private List<int> highScores = new List<int>();

    private void Start()
    {
        LoadScores();
        DisplayScores();
    }


    void LoadScores()
    {
        highScores.Clear();
        for (int i = 1; i <= 4; i++)
        {
            int score = PlayerPrefs.GetInt("HighScore" + i, 0);
            highScores.Add(score);
        }
    }

    void DisplayScores()
    {
        BestScoreText.text = highScores[0].ToString("N2");
        SecondScoreText.text = highScores[1].ToString("N2");
        ThirdScoreText.text = highScores[2].ToString("N2");
        FourthScore.text = highScores[3].ToString("N2");
    }
}
