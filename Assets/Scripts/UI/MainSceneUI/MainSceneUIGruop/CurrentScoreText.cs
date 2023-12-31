using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrentScoreText : MonoBehaviour
{
    private TMP_Text _scoreText;
    private int _currentScore;

    private void Awake()
    {
        _scoreText = transform.Find("CurrentScore").GetComponent<TMP_Text>();
    }

    public int ChangeCurrentScore
    {
        get { return _currentScore; }
        set
        {
            _currentScore = value;

            // 여기서 _scoreText가 null인지 체크
            if (_scoreText != null)
            {
                _scoreText.text = "현재 점수\n" + _currentScore.ToString();
            }
            else
            {
                Debug.LogError("Score text is null. Make sure it is assigned in the inspector.");
            }
        }
    }
}
