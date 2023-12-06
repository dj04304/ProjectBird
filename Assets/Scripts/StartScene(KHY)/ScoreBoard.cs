using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System.Text;

public class ScoreBoard : MonoBehaviour
{
    public GameObject board;
    public TextMeshProUGUI[] ScoreNames = new TextMeshProUGUI[] { };
    public TextMeshProUGUI[] ScoreValues = new TextMeshProUGUI[] { };

    private string[] tempNames = new string[9];
    private string[] tempValues = new string[9];
    private string ScorePath = Application.dataPath + "/" + "Data" + "/" + "ScoreData.csv";
    // Start is called before the first frame update
    void Start()
    {
        SaveNewScore("kim", 2000);
        ShowScore();

        //test
    }


    private void ShowScore()
    {
        StreamReader scoreData = new StreamReader(ScorePath);

        for (int cnt = 0; cnt < 9; cnt++)
        {
            string line = scoreData.ReadLine();
            string[] data = line.Split(',');
            ScoreNames[cnt].text = data[0];
            ScoreValues[cnt].text = data[1];
            tempNames[cnt] = data[0];
            tempValues[cnt] = data[1];
        }

        scoreData.Close();
    }

    /*private void ShowScore()
    {
        for(int cnt =0; cnt < 9; cnt++)
        {
            ScoreNames[cnt].text = tempNames[cnt];
            ScoreValues[cnt].text = tempValues[cnt];
        }
    }*/

    private void SaveNewScore(string Name, int score)
    {
        StreamReader scoreData1 = new StreamReader(ScorePath);

        for (int cnt = 0; cnt < 9; cnt++)
        {
            string line = scoreData1.ReadLine();
            string[] data = line.Split(',');
            tempNames[cnt] = data[0];
            tempValues[cnt] = data[1];
        }

        scoreData1.Close();

        StringBuilder sb = new StringBuilder();

        int tempCnt = 0;
        bool oneTime = true;
        for(int cnt=0; cnt < 9; cnt++)
        {
            if((int.Parse(tempValues[tempCnt]) <= score)&&(oneTime))
            {
                string t1 = Name + ',' + score.ToString();
                sb.AppendLine(t1);
                oneTime = false;
                Debug.Log("NEW SCORE SAVED!!!!");
            }
            else
            {
                string t2 = tempNames[tempCnt] + ',' + tempValues[tempCnt];
                sb.AppendLine(t2);
                tempCnt++;
            }
        }
        StreamWriter scoreData = new StreamWriter(ScorePath);
        scoreData.WriteLine(sb);
        scoreData.Close();
    }

    public void QuitScoreBoard()
    {
        SoundManager.Instance.playButtonEffect();
        board.SetActive(false);
    }
}
